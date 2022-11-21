using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario1.DAO
{
    public class RecordRow
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }

        // constructor, khoi tao cac gia tri cua thuoc tinh trong class
        public RecordRow(String firstName, String lastName, String age, String email, String salary, String department)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;
        }
    }
}
