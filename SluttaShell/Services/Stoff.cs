using System;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace SluttaShell.Services
{
    public enum StoffKind { Smoke, Snus }

    [Preserve(AllMembers = true)]
    // ReSharper disable once ClassNeverInstantiated.Global
    // constructed from json
    public class Stoff : INotifyPropertyChanged
    {
        const double NICOTINE_INTAKE_PER_UNIT = 1.1;
        const double TAR_INTANKE_PER_UNIT = 8;
        const double AMMONIA_INTAKE_PER_UNIT = 0.7948;

        static readonly CultureInfo _cultureInfo = new CultureInfo("nb-NO");

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore] public StoffKind Kind { get; set; }

        [JsonIgnore] bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                WeChanged("IsActive");
            }
        }

        public bool ShowChemicals
        {
            get;
            set;
        }

        [JsonIgnore] DateTime _quitDateTime;

        public DateTime QuitDateTime
        {
            get
            {
                return _quitDateTime;
            }
            set
            {
                _quitDateTime = value;
                WeChanged("QuitDateTime");
                WeChanged("QuitDate");
                WeChanged("QuitTime");
                NotifyUiShouldChange();
            }
        }

        [JsonIgnore]
        public DateTime QuitDate
        {
            get => QuitDateTime.Date;
            set => QuitDateTime = value.Date + QuitDateTime.TimeOfDay;
        }

        [JsonIgnore]
        public TimeSpan QuitTime
        {
            get => QuitDateTime.TimeOfDay;
            set => QuitDateTime = QuitDateTime.Date + value;
        }

        [JsonIgnore] int _antall;
        public int Antall
        {
            get
            {
                return _antall;
            }
            set
            {
                _antall = value;
                WeChanged("Antall");
                WeChanged("AntallPretty");
            }
        }

        [JsonIgnore]
        public string AntallPretty
        {
            get
            {
                return Antall.ToString();
            }
            set
            {
                if (Int32.TryParse(value, out var newAntall))
                {
                    Antall = newAntall;
                }
            }
        }

        [JsonIgnore] double _prisAsDouble;
        [JsonIgnore] string _pris;
        public string Pris
        {
            get
            {
                return _pris;
            }
            set
            {
                _pris = value;
                _prisAsDouble = (value == null) ? 0 : double.Parse(value, _cultureInfo);
                WeChanged("Pris");
                WeChanged("PrisAsDouble");
            }
        }
        [JsonIgnore] public double PrisAsDouble => _prisAsDouble;

        public string Grunn
        {
            get;
            set;
        }

        [JsonIgnore] double FractionalDays => (DateTime.Now - _quitDateTime).TotalDays;
        [JsonIgnore] public int Days => (int)FractionalDays;
        [JsonIgnore] public int Hours => (DateTime.Now - _quitDateTime).Hours;
        [JsonIgnore] public int Minutes => (DateTime.Now - _quitDateTime).Minutes;
        [JsonIgnore] public int Seconds => (DateTime.Now - _quitDateTime).Seconds;


        [JsonIgnore] public int TotalAntall => Math.Max((int)(Antall * FractionalDays), 0);

        [JsonIgnore]
        public string TotalAntallPretty => (Kind == StoffKind.Smoke)
            ? $"{TotalAntall} SIGARETTER TILSVARER"
            : $"{TotalAntall} SNUS TILSVARER";


        // calculate money saved here.
        [JsonIgnore] public int MoneySave2d => (DateTime.Now - _quitDateTime).Seconds;
        // first, return the floor of duration free days plus number smoked per day
        // get price per unit as a float
        // units multiplied by price per unit
        // also should probably be updated on the hour rather than the day. or even on the minute.
        // to do this, we need to figure out the number smoked per hour, then number smoked per minute
        // then run the units * price calc
        [JsonIgnore]
        public double MoneySaved
        {
            get
            {
                // get number smoked per minute.
                var UnitsPerMinute = (Antall / 24.0) / 60;
                // get how many minutes have passed in total since quit date
                var span = DateTime.Now.Subtract(_quitDateTime);
                var totalMinutesPassed = span.TotalMinutes;
                if (totalMinutesPassed < 0)
                {
                    totalMinutesPassed = 0;
                }
                // get number smoked every minute since quit date
                var totalUnitsAvoided = UnitsPerMinute * totalMinutesPassed;
                // money saved
                return PrisAsDouble * totalUnitsAvoided;
            }
        }
        public string MoneySavedPretty => string.Format(_cultureInfo, "{0:0.00}", MoneySaved);

        [JsonIgnore]
        public double NicotineAvoided =>TotalAntall * NICOTINE_INTAKE_PER_UNIT;

        public string NicotineAvoidedPretty => string.Format(_cultureInfo, "{0:0.#}", NicotineAvoided);

        [JsonIgnore]
        public double TarAvoided => TotalAntall * TAR_INTANKE_PER_UNIT;

        public string TarAvoidedPretty => string.Format(_cultureInfo, "{0:0.#}", TarAvoided);

        [JsonIgnore]
        public double AmmoniaAvoided => TotalAntall * AMMONIA_INTAKE_PER_UNIT;

        public string AmmoniaAvoidedPretty => string.Format(_cultureInfo, "{0:0.#}", AmmoniaAvoided);

        public string ShareFlavourText
        {
            get;
            set;
        }

        public bool HaveShownFirstDayPopup
        {
            get;
            set;
        }

        public void NotifyUiShouldChange()
        {
            WeChanged("Days");
            WeChanged("Hours");
            WeChanged("Minutes");
            WeChanged("Seconds");
            WeChanged("TotalAntall");
            WeChanged("TotalAntallPretty");
            WeChanged("MoneySaved");
            WeChanged("MoneySavedPretty");
            WeChanged("NicotineSaved");
            WeChanged("NicotineSavedPretty");
            WeChanged("TarAvoidedPretty");
            WeChanged("AmmoniaAvoidedPretty");
        }

        // we could use the [CallMemberName] approach, but as some things invalidate others we prefer this
        // way for how it's explicit. The use of strings isn't great but changing it now is more likely
        // to introduce bugs than fix them :P Feel free though, I would if I revisited this.
        void WeChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
