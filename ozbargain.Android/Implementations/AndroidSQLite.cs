using System;
using System.IO;
using ozbargain.Droid.Implementations;
using ozbargain.Persistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace ozbargain.Droid.Implementations
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, Database.DatabaseFile);

            return new SQLiteAsyncConnection(path);
        }
    }
}
