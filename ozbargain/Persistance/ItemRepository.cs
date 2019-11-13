using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ozbargain.Models;
using SQLite;

namespace ozbargain.Persistance
{
    public class ItemRepository : BaseRepository
    {
        public ItemRepository(SQLiteAsyncConnection connection)
            : base(connection)
        {
            _connection.CreateTableAsync<Item>();
        }

        public async Task<bool> Insert(Item item)
        {
            try
            {
                await _connection.InsertAsync(item);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            return true;
        }

        public async Task<List<Item>> All()
        {
            List<Item> results = null;
            try
            {
                results = await _connection.Table<Item>().ToListAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return results;
        }

        public async Task<int> Count()
        {
            int count = 0;
            try
            {
                count = await _connection.Table<Item>().CountAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return count;
        }
    }
}
