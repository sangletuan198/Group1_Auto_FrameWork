using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.DAO
{
    public class BookDAO

    {
        public string isbn { get; set; }
        public string title { get; set; }
        public string publisher { get; set; }
        public string author { get; set; }
        public BookDAO(string isbn, string title, string publisher, string author)
        {
            this.isbn = isbn;
            this.title = title;
            this.publisher = publisher;
            this.author = author;
        }
    }
    public class BooksDAO
    {
        public List<BookDAO> books { get; set; }  
    }
}
