using System;
using System.IO;
using ozbargain.iOS.Implementations;
using ozbargain.Persistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSSQLite))]
namespace ozbargain.iOS.Implementations
{
    public class IOSSQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, Database.DatabaseFile);

            return new SQLiteAsyncConnection(path);
        }
    }
}
