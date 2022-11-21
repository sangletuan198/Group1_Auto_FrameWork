using Scenario1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario.TestSetData
{
    public class TestSetData1
    {
        public List<RecordRow> testRows = new List<RecordRow>();
        public void CreateTestRows()
        {
            testRows.Add(new RecordRow("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance"));
            testRows.Add(new RecordRow("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance"));
            testRows.Add(new RecordRow("Kierra", "Gentry", "29", "kierra@example.com", "2000", "Legal"));
        }
    }
}

