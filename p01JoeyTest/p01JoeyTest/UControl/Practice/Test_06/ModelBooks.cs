using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace p01JoeyTest.UControl.Practice.Test_06
{
    public class ModelBooks //注意:原本是internal,要改成public,不能不寫,預設值應是private
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }

    public class BookManager
    {
        public static List<ModelBooks> GetBooks() //建立Function,在裡面建立List
        {
            var books = new List<ModelBooks>();

            books.Add(new ModelBooks { BookId = 1, Title = "Vulpate", Author = "Joey", CoverImage = "../../../Assets/ic_game_epic.png" });
            books.Add(new ModelBooks { BookId = 2, Title = "Sunday", Author = "Max", CoverImage = "../../../Assets/ic_game_gog.png" });
            books.Add(new ModelBooks { BookId = 3, Title = "Monday", Author = "Pitt", CoverImage = "../../../Assets/ic_game_ms_store.png" });
            books.Add(new ModelBooks { BookId = 4, Title = "Tuesday", Author = "Mike", CoverImage = "../../../Assets/ic_game_ubisoft.png" });
            books.Add(new ModelBooks { BookId = 5, Title = "Wednesday", Author = "Irene", CoverImage = "../../../Assets/ic_game_xbox.png" });
            books.Add(new ModelBooks { BookId = 6, Title = "Thrusday", Author = "Yen", CoverImage = "../../../Assets/ic_game_epic.png" });
            books.Add(new ModelBooks { BookId = 7, Title = "Friday", Author = "Michael", CoverImage = "../../../Assets/ic_game_epic.png" });
            books.Add(new ModelBooks { BookId = 8, Title = "Saturday", Author = "Neil", CoverImage = "../../../Assets/ic_game_ms_store.png" });
            books.Add(new ModelBooks { BookId = 9, Title = "Gold", Author = "Ray", CoverImage = "../../../Assets/ic_game_ubisoft.png" });
            books.Add(new ModelBooks { BookId = 10, Title = "Wood", Author = "Lingo", CoverImage = "../../../Assets/ic_game_xbox.png" });
            return books;
        }
    }
}
