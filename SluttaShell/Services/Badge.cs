using System.Collections.Generic;
using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SluttaShell.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // created via json deserialize
    public class Badge : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string stoff
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string time
        {
            get;
            set;
        }

        public string timeUnit
        {
            get;
            set;
        }

        public string timeMs
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public string imageurl
        {
            get;
            set;
        }

        public string imageurlsmall
        {
            get;
            set;
        }

        public string imageurlempty
        {
            get;
            set;
        }

        [JsonIgnore] bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                var oldVal = _isActive;
                _isActive = value;

                if (oldVal != _isActive)
                {
                    ImageUrlProcessed = value ? imageurlsmall : imageurlempty;
                    WeChanged("IsActive");
                    WeChanged("ImageUrlProcessed");
                }
            }
        }

        public string ImageUrlProcessed
        {
            get;
            set;
        }

        public string backgroundcolor
        {
            get;
            set;
        }

        public string buttoncolor
        {
            get;
            set;
        }

        public bool enabled
        {
            get;
            set;
        }

        public string prevtitle
        {
            get;
            set;
        }

        public List<TextNode> TextNodes
        {
            get;
            set;
        }

        public bool IsInPast(DateTime startDateTime)
        {
            var freeTimeSpan = DateTime.Now - startDateTime;
            if (Int32.TryParse(time, out var timeVal))
            {
                switch (timeUnit)
                {
                    case "minutes":
                        return TimeSpan.FromMinutes(timeVal) < freeTimeSpan;
                    case "hours":
                        return TimeSpan.FromHours(timeVal) < freeTimeSpan;
                    case "days":
                        return TimeSpan.FromDays(timeVal) < freeTimeSpan;
                    case "months":
                        var pointInTimeM = startDateTime.AddMonths(timeVal);
                        return pointInTimeM < DateTime.UtcNow;
                    case "years":
                        var pointInTimeY = startDateTime.AddYears(timeVal);
                        return pointInTimeY < DateTime.UtcNow;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        void WeChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
