using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.DAO
{
    public class UserDAO
    {
        public string staffCode { get; set; }
        public string username { get; set; }
        public string birthDate { get; set; }
        public string active { get; set; }


        public UserDAO(string staffCode, string username, string birthDate, string active)
        {
            this.staffCode = staffCode;
            this.username = username;
            this.birthDate = birthDate;
            this.active = active;

        }
    }
}
