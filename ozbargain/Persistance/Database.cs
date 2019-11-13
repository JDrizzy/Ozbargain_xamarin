using System;
using SQLite;
using Xamarin.Forms;

namespace ozbargain.Persistance
{
    public sealed class Database
    {
        private static readonly Lazy<Database>
            lazy =
            new Lazy<Database>
                (() => new Database());

        public static Database Instance { get { return lazy.Value; } }

        public const string DatabaseFile = "OzBargain.db";

        static SQLiteAsyncConnection _sqliteConnection;

        private Database()
        {
            _sqliteConnection = DependencyService.Get<ISQLite>().GetConnection();
        }

        public SQLiteAsyncConnection Connection()
        {
            return _sqliteConnection;
        }
    }
}
