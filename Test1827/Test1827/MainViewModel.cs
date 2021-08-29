using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using PCLStorage;

namespace Test1827
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NavigationLog> _navigationLog;
        private SQLiteConnection _db;

        public MainViewModel()
        {
            var dbName = "Test.db";


            var sqliteFilename = "Test.db";

            IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;

            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            //System.IO.Directory.CreateDirectory(path);

            //database = new DBOperations(Path.Combine(path));
            Db = new SQLiteConnection(Path.Combine(path));
            Db.CreateTable<NavigationLog>();
            NavigationLogs = new ObservableCollection<NavigationLog>();
            StartGetLocation();
        }

        public SQLiteConnection Db
        {
            get { return _db; }
            set { _db = value; }
        }

        public ObservableCollection<NavigationLog> NavigationLogs
        {
            get { return _navigationLog; }
            set { _navigationLog = value; OnPropertyChanged("NavigationLogs"); }
        }

        async void StartGetLocation()
        {
            var sqliteFilename = "Test.db";

            IFolder folder = PCLStorage.FileSystem.Current.LocalStorage;

            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);



            while (true)
            {
                var result = await Geolocation.GetLocationAsync(
                    new GeolocationRequest(GeolocationAccuracy.High));
                //, TimeSpan.FromMinutes(1)
                if (result != null)
                {
                    var navLog = new NavigationLog(result.Latitude, result.Longitude, DateTime.Now);
                    //NavigationLogs.Add(navLog);
                    Db.Insert(navLog);
                    List<NavigationLog> navLogList = GetAllNavigationLogs();
                    NavigationLogs.Clear();
                    foreach (var item in navLogList)
                    {
                        NavigationLogs.Add(item);
                    }


                }

                await Task.Delay(60000);
            }
        }

        private List<NavigationLog> GetAllNavigationLogs()
        {
            return Db.CreateCommand("SELECT * FROM NavigationLog").ExecuteQuery<NavigationLog>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
