namespace ATEN_Util
{
    public class EmployeeModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string enable { get; set; }
        public string updateTime { get; set; }
        public string awardGroups { get; set; }

        public bool IsInGroup(string label)
        {
            string[] labelList = awardGroups.Split(',');

            if (null != labelList)
            {
                foreach (string token in labelList)
                {
                    if (token.Equals(label))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
