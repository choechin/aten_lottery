using ATEN_Util.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace ATEN_Util.Service
{
    public class LuckyListService
    {
        public List<LuckyListModel> GetLuckyList(string award)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                return cn.Query<LuckyListModel>(
                    "SELECT * FROM lucky_list WHERE award=@award ORDER BY updateTime",
                    new LuckyListModel() { award = award }
                    ).ToList();
            }
        }

        public void InsertLuckyList(LuckyListModel luckyList)
        {
            luckyList.updateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute(
                        "INSERT INTO lucky_list (empId, name, department, job, award, updateTime)"
                        + " VALUES (@empId, @name, @department, @job, @award, @updateTime)",
                        luckyList, trans);
                    trans.Commit();
                }
            }

        }

        public void RevokeLuckyList(string employeeId)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("UPDATE lucky_list SET award='X' WHERE empid=@empId;",
                        new LuckyListModel() { empId = employeeId },
                        trans);
                    trans.Commit();
                }
            }
        }
    }
}
