using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Test1827
{
    [Table("NavigationLog")]
    public class NavigationLog : INotifyPropertyChanged
    {
        private double _latitude;
        private double _longitude;
        private DateTime _date;

        public NavigationLog()
        {

        }
        public NavigationLog(double latitude, double longitude, DateTime date)
        {
            _latitude = latitude;
            _longitude = longitude;
            _date = date;
        }
        [Column("Latitude")]
        public double Latitude
        {

            get { return _latitude; }
            set { _latitude = value; OnPropertyChanged("Latitude"); }
        }
        [Column("Longitude")]
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; OnPropertyChanged("Longitude"); }
        }

        [Column("Date")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("Date"); }
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
