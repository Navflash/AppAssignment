using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace phoneApp
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<Users>().Wait();
        }

        //Insert and update
        public Task<int> SaveItemAsync(Users users)
        {
            if (users.UserID != 0)
            {
                return db.UpdateAsync(users);
            }
            else
            {
                return db.InsertAsync(users);
            }
        }

        //Delete User
        public Task<int> DeleteItemAsync(Users users)
        {
            return db.DeleteAsync(users);
        }

        //Read all
        public Task<List<Users>> GetUsersAsync()
        {
            return db.Table<Users>().ToListAsync();
        }

        //Read User
        public Task<Users> GetUser(int userId)
        {
            return db.Table<Users>().Where(i => i.UserID == userId).FirstOrDefaultAsync();
        }
    }
}
