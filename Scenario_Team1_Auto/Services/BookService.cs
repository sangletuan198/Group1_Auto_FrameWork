using CoreFramework.APICore;
using Newtonsoft.Json;
using NUnit.Framework;
using Scenario_Team1_Auto.DAO;
using Scenario_Team1_Auto.TestSetup;


namespace Scenario_Team1_Auto.Services
{
    public class BookService
    {
        private string getBookPath = "/BookStore/v1/Books";

        public APIResponse GetBookRequest(string token)
        {
            APIResponse response = new APIRequest()
                .SetUrl(Constant.BOOK_STORE_HOST + getBookPath)
                .AddHeader("Authorization", "Bearer" + token)
                .Get();
            return response;
        }

        public BooksDAO GetBooks(string token)
        {
            APIResponse response = GetBookRequest(token);
            Assert.True(response.responseStatusCode.Equals("OK"));
            var jsonResponse = response.responseBody;
            BooksDAO books = (BooksDAO)JsonConvert.DeserializeObject<BooksDAO>(jsonResponse);
            return books;
        }
    }
}
