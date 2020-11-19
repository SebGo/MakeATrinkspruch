using Android.App;
using MakeATrinkspruch.Droid;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Database))]

namespace MakeATrinkspruch.Droid
{
    public class Database : IDatabase
    {
        public SQLiteAsyncConnection CreateConnection()
        {
            string sqliteFileName = "MakeATrinkspruch.db3";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "MakeATrinkspruch");
            string path = Path.Combine(documentsDirectoryPath, sqliteFileName);
            //if (!Directory.Exists(documentsDirectoryPath))
            //{
            //    Directory.CreateDirectory(documentsDirectoryPath);
            //}
            if (!File.Exists(path))
            {
                using (BinaryReader binaryReader = new BinaryReader(Application.Context.Assets.Open(sqliteFileName)))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(path);
            return connection;
        }
    }
}