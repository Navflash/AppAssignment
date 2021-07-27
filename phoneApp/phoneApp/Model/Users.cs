using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace phoneApp
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}
