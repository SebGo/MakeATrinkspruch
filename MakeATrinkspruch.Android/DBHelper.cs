namespace MakeATrinkspruch
{
    using Android.Content;
    using Android.Database.Sqlite;
    using System;
    using System.IO;

    namespace MakeATrinkspruch
    {
        public class DBHelper : SQLiteOpenHelper
        {
            private string dbPath; // DB_PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            private string dbName; // DB_NAME = "MakeAToast.db3";
            private static int VERSION = 1;
            private Context context;
            public DBHelper(Context context, string dbPath, string dbName) : base(context, dbName, null, VERSION)
            {
                this.context = context;
                this.dbName = dbName;
                this.dbPath = dbPath;
                CreateOrCopyDatabase();
            }

            public bool CreateOrCopyDatabase()
            {
                string path = Path.Combine(dbPath, dbName);
                bool isSQLiteInit = false;
                try
                {
                    if (File.Exists(path))
                        isSQLiteInit = true;
                    else
                    {
                        Stream streamSQLite = context.Resources.OpenRawResource(Resource.Raw.MakeAToast);
                        FileStream streamWriter = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        if (streamSQLite != null && streamWriter != null)
                        {
                            if (CopySQLiteDB(streamSQLite, streamWriter))
                                isSQLiteInit = true;
                        }
                    }
                }
                catch { }
                return isSQLiteInit;
            }




            private bool CopySQLiteDB(Stream streamSQLite, FileStream streamWriter)
            {
                bool isSuccess = false;
                int lenght = 256;
                Byte[] buffer = new Byte[lenght];
                try
                {
                    int bytesRead = streamSQLite.Read(buffer, 0, lenght);
                    while (bytesRead > 0)
                    {
                        streamWriter.Write(buffer, 0, bytesRead);
                        bytesRead = streamSQLite.Read(buffer, 0, lenght);
                    }
                    isSuccess = true;
                }
                catch { }
                finally
                {
                    streamSQLite.Close();
                    streamWriter.Close();
                }
                return isSuccess;
            }
            public override void OnCreate(SQLiteDatabase db)
            {
            }
            public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
            {
            }
        }
    }
}