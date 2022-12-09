using Scenario_Team1_Auto.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.TestData
{
    public class CreateAssetTestData
    {
        public List<AssetDAO> assetData = new List<AssetDAO>();
        public void CreateAssetData()
        {
            assetData.Add(new AssetDAO("MacBook Air M1", "Laptop", "Chip M1 16GB Ram", "2022-12-07", "Not Available"));//Available,Not Available
        }
    }
}
