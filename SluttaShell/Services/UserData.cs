using System.Collections.Generic;
using System.ComponentModel;

namespace SluttaShell.Services
{
    public class UserData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Stoff> StoffList { get; set; }

        BadgeInfo _badgeInfo;
        public BadgeInfo BadgeInfo
        {
            get => _badgeInfo;
            set
            {
                _badgeInfo = value;
                WeChanged("BadgeInfo");
            }
        }

        void WeChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

