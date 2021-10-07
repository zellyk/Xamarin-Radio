using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    public class DBEmployee
    {
        readonly SQLiteAsyncConnection _database;
        public DBEmployee(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();
        }

        public Task<List<Employee>> GetEmployeeAsync()
        {
            return
            _database.Table<Employee>().ToListAsync();
        }
        public Task<int> SaveEmployeeAsync(Employee employee)
        {
            return _database.InsertAsync(employee);
        }
    }
}
