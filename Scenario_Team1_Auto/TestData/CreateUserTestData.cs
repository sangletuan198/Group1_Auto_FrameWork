using Scenario_Team1_Auto.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestData
{
    public class CreateUserTestData
    {
        public List<CreateUserInfoDAO> userData = new List<CreateUserInfoDAO>();
        public void CreateUserData()
        {
            userData.Add(new CreateUserInfoDAO("1998-02-24", "2022-12-13", "Sang", "MALE", "Le Tuan", "ADMIN"));
            userData.Add(new CreateUserInfoDAO("1999-12-04", "2022-12-13", "Lu", "MALE", "Do Thi Ngoc", "STAFF"));
        }
    }
}
