using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.Services
{
    public class AssetService
    {
        private string getAssetPath = "/api/v1/admin/assets?searchTerm=&cateFill=&stateFill=&pageSize=10&pageNo=1&sortBy=assetId&sortDir=asc";
                                     ///api/v1/admin/assets?searchTerm=&cateFill=&stateFill=&pageSize=10&pageNo=1&sortBy=assetId&sortDir=asc
                                    //api/v1/admin/assets?searchTerm=&cateFill=&stateFill=&pageSize=10&pageNo=1&sortBy=assetId&sortDir=asc
        public APIResponse GetAssetRequest(string token)
        {
            APIResponse response = new APIRequest()
                .SetUrl(Constant.NASH_HOST + getAssetPath)
                .AddHeader("Authorization", "Bearer " + token)
                .Get();
            return response;
        }
        public AssetsDAO? GetAssets(string token)
        {
            APIResponse response;
            try {
                response = GetAssetRequest(token);
                Assert.True(response.responseStatusCode.Equals("OK"));
                var jsonResponse = response.responseBody;
                AssetsDAO? assets = (AssetsDAO?) JsonConvert.DeserializeObject<AssetsDAO>(jsonResponse);
                return assets;
            } catch (Exception ex) { 
                TestContext.WriteLine(ex);
            }
            return null;
        }
    }
}
