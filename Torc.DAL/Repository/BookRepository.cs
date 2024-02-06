using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torc.DAL.EntityFramework;

namespace Torc.DAL.Repository
{
    public class BookRepository
    {
        protected BookLibraryContext Db;
        protected DbSet<Book> DbSet;

        public BookRepository(BookLibraryContext context)
        {
            Db = context;
            DbSet = Db.Set<Book>();
        }

        public virtual async Task<Book> FindById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooks(string searchBy, string searchValue)
        {
            using (var conn = Db.Database.GetDbConnection())
            {
                var books = await conn.QueryAsync<Book>("SELECT * FROM books WHERE " + searchBy + " LIKE '%' + @SearchValue + '%'",
                    new { SearchValue = searchValue });

                return books;
            }
        }
    }
}
