using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.DAO
{
    public class AuthorizationDAO
    {
        public string accessToken { get; set; }
        public string role { get; set; }
       
        public AuthorizationDAO(string accessToken, string role)
        {
            this.accessToken = accessToken;
            this.role = role;
        }
    }
}
