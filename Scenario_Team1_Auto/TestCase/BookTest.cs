using NUnit.Framework;
using RookiesTest.TestSetup;
using Scenario_Team1_Auto.DAO;

namespace RookiesTest.APITest
{
    [TestFixture]
    public class BookTest : NUnitAPITestSetup
    {
        [Test]
        public void ListBookTest()
        {
            BooksDAO expectedBooks = bookService.GetBooks(user.token);
            TestContext.WriteLine(expectedBooks.books[0].title);// for tu 0 den length lay ra toan bo guia tri ,,,,
            // open page
            // listbookpage = new listbookPage
            //  List<BookDAO> actualbook = listbookPage.getDisplayedBook();
            //compare  
        }
        public void EditBookTest()
        {
            // bookservice.createbook(user.token, bookdata - testadata minh tao de edit)
            // open page
            // listbookpage = new listbookPage
            //listbookpage -> select created book 
            //compare  
        }
    } 
}