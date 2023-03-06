using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPharma.Models
{
    public class DBSqlite
    {
        private DBSqlite()
        {
            CreateAllTables();
        }

        static DBSqlite sql = null;
        public static DBSqlite SqliteObjCheck()
        {
            if (sql is null)
            {
                sql = new();
            }
            return sql;
        }

        SQLiteAsyncConnection Database;
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            //await CreateAllTables();
        }

        internal async Task CreateAllTables()
        {
            if (Services.AllStatics.IsSqlTablesCreated)
            {
                return;
            }
            // If not then it will create each tables given otherwise it will migrate
            await Init();
            try
            {
                var re = await Database.CreateTableAsync<Employee>();
            }
            catch (Exception ex)
            {
                throw;
            }
            await Database.CreateTableAsync<Profile>();
            await Database.CreateTableAsync<Dept>();
            Services.AllStatics.IsSqlTablesCreated = true;


        }


        public async Task<int> InsertIntoSql(Object ob)
        {
            await Init();

            int insertedNoOfRows = await Database.InsertAsync(ob);
            return insertedNoOfRows;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            await Init();
            
            List<Employee> retrivedRresult = await Database.Table<Employee>().ToListAsync();

            return retrivedRresult;
        }

        public async Task<int> DeleteEmployee()
        {
            await Init();
            var result = await Database.DeleteAllAsync<Employee>();
            return result;
        }
    }
}
