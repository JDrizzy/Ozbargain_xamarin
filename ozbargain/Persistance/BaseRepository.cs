using System;
using SQLite;

namespace ozbargain.Persistance
{
    public class BaseRepository
    {
        public SQLiteAsyncConnection _connection { get; set; }

        public BaseRepository(SQLiteAsyncConnection connection)
        {
            _connection = connection;
        }
    }
}
