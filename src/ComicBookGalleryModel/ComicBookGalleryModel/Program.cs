using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The Amazing Spider-Man",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });
                context.SaveChanges();

                var comicBooks = context.ComicBooks.ToList();
                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.SeriesTitle);
                }

                Console.ReadLine();
            }
        }
    }
}
