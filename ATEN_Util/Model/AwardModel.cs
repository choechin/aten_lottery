using System;

namespace ATEN_Util.Model
{
    public class AwardModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string qty { get; set; }
        public string new_qty { get; set; }
        public string seq { get; set; }
        public string status { get; set; }
        public string awardGroup { get; set; }

        public int GetQuantity()
        {
            return Convert.ToInt32(qty);
        }

        public int GetUsedQuantity()
        {
            return Convert.ToInt32(new_qty);
        }

        public bool IsAvailable()
        {
            return GetQuantity() > GetUsedQuantity();
        }

        public bool IsDisabled()
        {
            return "0".Equals(status);
        }

        public void DisableAward()
        {
            status = "0";
        }
    }
}
