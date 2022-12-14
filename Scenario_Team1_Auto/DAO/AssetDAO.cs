using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.DAO
{
    public class AssetDAO
    {
        public string name { get; set; }
        public string category { get; set; }
        public string specification { get; set; }
        public string installedDate { get; set; }
        public string state { get; set; }


        public AssetDAO(string name, string category, string specification, string installedDate, string state)
        {
            this.name = name;
            this.category = category;
            this.specification = specification;
            this.installedDate = installedDate;
            this.state = state;


        }
    }
}