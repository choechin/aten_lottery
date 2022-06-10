using ATEN_Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATEN_Util.Service
{
    public class LotteryProcess
    {
        private EmployeeService employeeService = new EmployeeService();
        private AwardService awardService = new AwardService();
        private LuckyListService luckyListService = new LuckyListService();

        private Random random = new Random(DateTime.Now.Second);

        public List<AwardModel> AwardList { get; private set; }
        public List<EmployeeModel> AvailableEmployees { get; private set; }

        public LotteryProcess()
        {
            AwardList = awardService.GetAvailableAwards();//取得未抽獎項清單
            AvailableEmployees = employeeService.GetAvailableEmployeeList();//取得未中獎人員
        }

        public AwardModel GetAwardById(string id)
        {
            foreach (AwardModel award in AwardList)
            {
                if (award.id.Equals(id))
                {
                    return award;
                }
            }

            return null;
        }

        private void Validate(AwardModel award)
        {
            if (null == award)
            {
                throw new ArgumentNullException("award is null");
            }

            if (false == AwardList.Contains(award))
            {
                throw new ArgumentException("award is not in list: " + award.name);
            }

            if(false == award.IsAvailable())
            {
                throw new ArgumentException("award is not available: " + award.name);
            }

            if (award.IsDisabled())
            {
                throw new ArgumentException("award is not disabled: " + award.name);
            }
        }

        private List<EmployeeModel> GetLotteryCandidates(AwardModel award)
        {
            List<EmployeeModel> candidates = new List<EmployeeModel>();

            foreach (EmployeeModel emp in AvailableEmployees)
            {
                if (emp.IsInGroup(award.awardGroup))
                {
                    candidates.Add(emp);
                }
            }

            return candidates;
        }

        /// <summary>
        /// 進行抽獎
        /// </summary>
        /// <param name="award">獎項</param>
        /// <param name="candidates">抽獎人員</param>
        /// <returns></returns>
        private EmployeeModel GetWinnerFromCandidates(AwardModel award, List<EmployeeModel> candidates)
        {
            EmployeeModel winner = candidates.ElementAt(random.Next(candidates.Count()));

            // remove winner
            candidates.Remove(winner);
            AvailableEmployees.Remove(winner);
            employeeService.DisableEmployee(winner.id);

            // add lucky list
            luckyListService.InsertLuckyList(new LuckyListModel()
            {
                empId = winner.id,
                name = winner.name,
                department = winner.department,
                job = winner.job,
                award = award.name
            });

            // update award
            award.new_qty = (award.GetUsedQuantity() + 1).ToString();

            if (false == award.IsAvailable())
            {
                award.DisableAward();
            }

            awardService.UpdateAward(award);

            return winner;
        }

        /// <summary>
        /// 中獎名單
        /// </summary>
        /// <param name="award"></param>
        /// <returns></returns>
        public List<EmployeeModel> GetWinners(AwardModel award)
        {
            Validate(award);
            List<EmployeeModel> candidates = GetLotteryCandidates(award);

            List<EmployeeModel> winnerList = new List<EmployeeModel>();
            int qty = award.GetQuantity();

            for (int i = 0; i < qty; i++)
            {
                EmployeeModel winner = GetWinnerFromCandidates(award, candidates);
                winnerList.Add(winner);
            }

            // remove award
            AwardList.Remove(award);

            return winnerList;
        }

        public EmployeeModel GetOneWinner(AwardModel award)
        {
            Validate(award);
            return GetWinnerFromCandidates(award, GetLotteryCandidates(award));
        }

        public void RevokeWinner(AwardModel award, EmployeeModel winner)
        {
            if (award.GetUsedQuantity() == 0)
            {
                throw new ArgumentException("award is not gived away yet and cannot be revoked: " +
                    award.name);
            }

            luckyListService.RevokeLuckyList(winner.id);

            award.new_qty = (award.GetUsedQuantity() - 1).ToString();
            award.status = "1";
            awardService.UpdateAward(award);
        }

        public List<string> RecoverWinnerNameList(AwardModel award)
        {
            List<LuckyListModel> luckyLists = luckyListService.GetLuckyList(award.name);

            List<string> names = new List<string>();

            foreach (LuckyListModel m in luckyLists)
            {
                names.Add(m.name);
            }

            return names;
        }

        public void ValidatePreRequirements()
        {
            if (0 == AwardList.Count)
            {
                throw new ArgumentException("獎項未設定或已全部抽完, 請使用 ATEN_Lottery_Manager 進行維護");
            }

            if (0 == AvailableEmployees.Count)
            {
                throw new ArgumentException("員工未設定, 請使用 ATEN_Lottery_Manager 匯入");
            }

            Dictionary<string, int> awardTotal = new Dictionary<string, int>();

            foreach (AwardModel award in AwardList)
            {
                if (awardTotal.ContainsKey(award.awardGroup))
                {
                    awardTotal[award.awardGroup] = awardTotal[award.awardGroup] + award.GetQuantity();
                }
                else
                {
                    awardTotal.Add(award.awardGroup, award.GetQuantity());
                }
            }

            Dictionary<string, int> groupToCandidateMap = new Dictionary<string, int>();

            foreach (string awardGroup in awardTotal.Keys)
            {
                if (false == groupToCandidateMap.ContainsKey(awardGroup))
                {
                    groupToCandidateMap.Add(awardGroup, 0);
                }

                foreach (EmployeeModel employee in AvailableEmployees)
                {
                    if (employee.IsInGroup(awardGroup))
                    {
                        groupToCandidateMap[awardGroup] = groupToCandidateMap[awardGroup] + 1;
                    }
                }
            }

            foreach (string awardGroup in awardTotal.Keys)
            {
                if (awardTotal[awardGroup] > groupToCandidateMap[awardGroup])
                {
                    // insufficent employees for this award
                    throw new ArgumentException(
                        "獎項餘額大於員工人數, 無法正常抽獎, 請使用 ATEN_Lottery_Manager 重新設定獎項.");
                }
            }
        }
    }
}
