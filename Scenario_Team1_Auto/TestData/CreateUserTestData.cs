﻿using Scenario_Team1_Auto.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestData
{
    public class CreateUserTestData
    {
        public List<UserDAO> userData = new List<UserDAO>();
        public void CreateUserData()
        {
            userData.Add(new UserDAO("1998-02-24", "2022-12-05", "Sang", "MALE", "Le", "ADMIN"));
        }
    }
}
