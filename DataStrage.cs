using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeknajStudyManager
{
    public class TaskTable
    {
        [PrimaryKey, AutoIncrement]
        public uint TaskId { get; set; }
        public string? Subject { get; set; }
        public DateTime TimeLimit { get; set; }
        public string? TimeLimitType { get; set; }
        public string? ISBN { get; set; }
        public string? Name { get; set; }
        public int Range_start { get; set; }
        public int Range_end { get; set; }
        public string? Range_unit { get; set; }
        public string? Status { get; set; }
        public string? Memo { get; set; }
        public string? Origin { get; set; }
        public string? Type { get; set; }
    }

    public class ProcessTable
    {
        [PrimaryKey, AutoIncrement]
        public int ProcessId { get; set; }
        public int TaskId { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public int Start_Pos { get; set; }
        public int End_Pos { get; set; }
        public string? Place { get; set; }
    }
    public class DataStrage
    {
        private readonly SQLiteAsyncConnection _database;

        public DataStrage()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveddata.db");
            _database = new SQLiteAsyncConnection(dbPath);
            if (_database.TableMappings.Any(m => m.TableName == "TaskTable"))
            {
                Console.WriteLine("テーブル TaskTable が存在します。");
            }
            else
            {
                Console.WriteLine("テーブル TaskTable が存在しません。");
                _database.CreateTableAsync<TaskTable>().Wait();
            }
            if (_database.TableMappings.Any(m => m.TableName == "ProcessTable"))
            {
                Console.WriteLine("テーブル ProcessTable が存在します。");
            }
            else
            {
                Console.WriteLine("テーブル ProcessTable が存在しません。");
                _database.CreateTableAsync<ProcessTable>().Wait();
            }
        }

        // TaskTableの操作メソッド
        public async Task<int> InsertTaskAsync(TaskTable item)
        {
            return await _database.InsertAsync(item);
        }

        public async Task<int> ClearTaskAsync()
        {
            await _database.ExecuteAsync("DROP TABLE IF EXISTS TaskTable;");
            await _database.CreateTableAsync<TaskTable>();
            return 0;
        }

        public async Task<List<TaskTable>> GetAllTasksAsync()
        {
            return await _database.Table<TaskTable>().ToListAsync();
        }

        // ProcessTableの操作メソッド
        public async Task<int> InsertProcessAsync(ProcessTable item)
        {
            return await _database.InsertAsync(item);
        }
        public async Task<int> ClearProcessAsync()
        {
            await _database.ExecuteAsync("DROP TABLE IF EXISTS ProcessTable;");
            await _database.CreateTableAsync<ProcessTable>();
            return 0;
        }

        public async Task<List<ProcessTable>> GetAllProcessesAsync()
        {
            return await _database.Table<ProcessTable>().ToListAsync();
        }
    }
}
