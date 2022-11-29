using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.DAO
{
    public class AssignmentDAO
    {
        public string No { get; set; }
        public string Assetcode { get; set; }
        public string AssetName { get; set; }
        public string AssetTo { get; set; }
        public string AssetBy { get; set; }
        public string AssetDate { get; set; }
        public string State { get; set; }

        public AssignmentDAO(string no, string assetcode, string assetName, string assetTo, string assetBy, string assetDate, string state)
        {
            No = no;
            Assetcode = assetcode;
            AssetName = assetName;
            AssetTo = assetTo;
            AssetBy = assetBy;
            AssetDate = assetDate;
            State = state;
        }
    }
}
