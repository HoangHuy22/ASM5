using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUWP.Adapters
{
    class SQLiteHelper
    {
        private readonly string DB_Name = "food.db";
        private static SQLiteHelper _sQLiteHelper;

        public static SQLiteHelper createInstance()
        {
            if (_sQLiteHelper == null)
            {
                _sQLiteHelper = new SQLiteHelper();
            }
            return _sQLiteHelper;
        }

        private SQLiteHelper()
        {
            sQLiteConnection = new SQLiteConnection(DB_Name);
            CreateProductTable();
            CreateCartTable();
        }

        public SQLiteConnection sQLiteConnection
        {
            get;
            private set;
        }

        private void CreateProductTable()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS Products(id integer primary key, name varchar(200), image varchar(200), description varchar(200), price integer)";
            var statement = sQLiteConnection.Prepare(sql);
            statement.Step();
        }

        private void CreateCartTable()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS Cart(id integer primary key, name varchar(200), image varchar(200), price integer, qty integer)";
            var statement = sQLiteConnection.Prepare(sql);
            statement.Step();
        }

    }
}
