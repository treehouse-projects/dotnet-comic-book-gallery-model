using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBookId = 1;

                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                var comicBook1 = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .SingleOrDefault(cb => cb.Id == comicBookId);

                Debug.WriteLine("Changing the Description property value.");
                comicBook1.Description = "New value!";

                var comicBook2 = context.ComicBooks
                    .SingleOrDefault(cb => cb.Id == comicBookId);

                //var comicBooks = context.ComicBooks
                //    //.Include(cb => cb.Series)
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    if (comicBook.Series == null)
                //    {
                //        context.Entry(comicBook)
                //            .Reference(cb => cb.Series)
                //            .Load();
                //    }

                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
