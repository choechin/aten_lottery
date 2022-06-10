using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace ATEN_Util.Service
{
    public class EmployeeService
    {
        public void DisableEmployee(string employeeId)
        {
            EmployeeModel employee = new EmployeeModel() {
                id = employeeId
            };

            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("UPDATE employee SET enable=0 WHERE id=@id", employee);
                    trans.Commit();
                }
            }
        }

        public List<EmployeeModel> LoadEmployee()
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                IEnumerable<EmployeeModel> output = cn.Query<EmployeeModel>(
                    "SELECT * FROM employee ORDER BY id");
                return output.ToList();
            }
        }

        public List<EmployeeModel> GetAvailableEmployeeList()
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                return cn.Query<EmployeeModel>("SELECT * FROM employee WHERE enable='1'")
                    .ToList();
            }
        }

        public void ImportEmployeeList(List<EmployeeModel> employeeModels)
        {
            using (SQLiteConnection cn = Conn.ConnDB())
            {
                using (SQLiteTransaction trans = cn.BeginTransaction())
                {
                    cn.Execute("DELETE FROM employee");
                    cn.Execute(
                        "INSERT INTO employee (id, name, department, job, enable, updateTime, awardGroups)"
                        + " VALUES (@id, @name, @department, @job, @enable, @updateTime, @awardGroups)",
                        employeeModels, trans);
                    trans.Commit();
                }

            }
        }
    }
}
