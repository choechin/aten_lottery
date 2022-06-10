using ATEN_Util;
using System;
using System.Collections.Generic;

namespace ATEN_Lottery_Manager.Utils
{
    class EmployeeModelComparer : IComparer<EmployeeModel>
    {
        public int Compare(EmployeeModel x, EmployeeModel y)
        {
            if (false == x.awardGroups.Equals(y.awardGroups))
            {
                return x.awardGroups.CompareTo(y.awardGroups);
            }

            if (false == x.department.Equals(y.department))
            {
                return x.department.CompareTo(y.department);
            }

            if (false == x.job.Equals(y.job))
            {
                return x.job.CompareTo(y.job);
            }

            if (false == x.name.Equals(y.name))
            {
                return x.name.CompareTo(y.name);
            }

            return x.id.CompareTo(y.id);
        }
    }
}
