using ATEN_Util.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace ATEN_Util.Service
{
    public class AwardService
    {
        public List<AwardModel> GetAvailableAwards()
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                IEnumerable<AwardModel> output = cn.Query<AwardModel>(
                    "SELECT * FROM award WHERE status=1 ORDER BY CAST(seq AS int)");
                return output.ToList();
            }
        }

        [ObsoleteAttribute]
        public void UpdateAwardQty(string id)
        {
            AwardModel award = new AwardModel()
            {
                id = id
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("UPDATE award SET new_qty=new_qty+1 WHERE id=@id", award);
                    trans.Commit();
                }
            }
        }

        [ObsoleteAttribute]
        public void DisableAwardForSingleLottery(string id)
        {
            AwardModel award = new AwardModel()
            {
                id = id
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    // TODO remove "please select" from database and we don't need "qty <> 0" here.
                    cn.Execute(
                        "UPDATE award SET status=0 WHERE new_qty=qty and qty <> 0 and id=@id",
                        award);
                    trans.Commit();
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="name">獎項名稱</param>
        /// <param name="qty">獎項名額</param>
        /// <param name="seq">獎項順序</param>
        /// <param name="awardGroup">獎項分類</param>
        public void AddAward(string name, string qty, string seq, string awardGroup)
        {
            AwardModel awardModel = new AwardModel()
            {
                name = name,
                qty = qty,
                new_qty = "0",
                seq = seq,
                status = "1",
                awardGroup = awardGroup
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute(
                        "INSERT INTO award (name, qty, new_qty, seq, status, awardGroup)"
                        + " VALUES (@name, @qty, @new_qty, @seq, @status, @awardGroup)",
                        awardModel);
                    trans.Commit();
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="awardModel"></param>
        public void UpdateAward(AwardModel awardModel)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("UPDATE award"
                        + " SET name=@name, qty=@qty, new_qty=@new_qty, seq=@seq, status=@status"
                        + ", awardGroup=@awardGroup"
                        + " WHERE id=@id",
                        awardModel);
                    trans.Commit();
                }
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAward(string id)
        {
            AwardModel awardModel = new AwardModel()
            {
                id = id
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("DELETE FROM award WHERE id=@id ", awardModel);
                    trans.Commit();
                }
            }
        }

        /// <summary>
        /// Excel匯入
        /// </summary>
        /// <param name="awardModel"></param>
        public void ImportAwardList(List<AwardModel> awardModel)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("DELETE FROM award");
                    cn.Execute(
                        "INSERT INTO award (name, qty, seq, status, awardGroup)"
                        + " VALUES (@name, @qty, @seq, '1', @awardGroup)",
                        awardModel, trans);
                    trans.Commit();
                }
            }
        }

        public AwardModel GetAwardById(string id)
        {
            AwardModel model = new AwardModel()
            {
                id = id
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                return cn.QuerySingle<AwardModel>(
                    "SELECT * FROM award WHERE id=@id ORDER BY seq",
                    model);
            }
        }
    }
}
