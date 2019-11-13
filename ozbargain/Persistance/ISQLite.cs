using System;
using SQLite;

namespace ozbargain.Persistance
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
