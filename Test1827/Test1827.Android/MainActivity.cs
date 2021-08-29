using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace Test1827.Droid
{
    [Activity(Label = "Test1827", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("Test.db");
            //string backupfile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "backend.db3");
            string backupfile = Path.Combine((string)Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments), "backup.db");

            //string backupfile = Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, "backup.db");

            File.Copy(dbPath, backupfile, true); 

            base.OnCreate(savedInstanceState);
             
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class FileAccessHelper
        {
            public static string GetLocalFilePath(string filename)
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //  string path = System.Environment.GetFolderPath(Android.OS.Environment.SpecialFolder.Personal);
                string dbPath = Path.Combine(path, filename);

                CopyDatabaseIfNotExists(dbPath);

                return dbPath;
            }

            private static void CopyDatabaseIfNotExists(string dbPath)
            {
                try
                {
                    if (!File.Exists(dbPath))
                    {
                        using (var br = new BinaryReader(Application.Context.Assets.Open("Test.db")))
                        {
                            using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                            {
                                byte[] buffer = new byte[2048];
                                int length = 0;
                                while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    bw.Write(buffer, 0, length);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}