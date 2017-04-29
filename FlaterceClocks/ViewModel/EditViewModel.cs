using FlaterceClocks.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaterceClocks.ViewModel
{
    public class EditViewModel : ViewModelBase
    {
        private Alarm alarm;

        private IMessage[] options =
        {
            new SoundMessage(),
            new TextMessage(),
            new ShutdownMessage(),
            new ShutdownMessage()
        };

        public EditViewModel()
        {
            MessengerInstance.Register<AlarmEditingMessage>(this, RecieveAndApplyAlarm);

            AddDayCommand = new RelayCommand<DayOfWeek>(AddDay);
            RemoveDayCommand = new RelayCommand<DayOfWeek>(RemoveDay);
            ConfirmCommand = new RelayCommand(Confirm);
        }

        string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }


        bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    RaisePropertyChanged("IsEnabled");
                }
            }
        }


        int hours;
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (hours != value)
                {
                    hours = value;
                    RaisePropertyChanged("Hours");
                }
            }
        }

        int minutes;
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (minutes != value)
                {
                    minutes = value;
                    RaisePropertyChanged("Minutes");
                }
            }
        }

        int seconds;
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (seconds != value)
                {
                    seconds = value;
                    RaisePropertyChanged("Seconds");
                }
            }
        }

        IMessage message;
        public IMessage Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }

        int selectedOption = 0;
        public int SelectedOption
        {
            get
            {
                return selectedOption;
            }
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    RaisePropertyChanged("SelectedOption");
                }
            }
        }

        string textMessage = string.Empty;
        public string TextMessage
        {
            get
            {
                return textMessage;
            }
            set
            {
                if (textMessage != value)
                {
                    textMessage = value;
                    RaisePropertyChanged("TextMessage");
                }
            }
        }

        string soundPath;
        public string SoundPath
        {
            get
            {
                return soundPath;
            }
            set
            {
                if (soundPath != value)
                {
                    soundPath = value;
                    RaisePropertyChanged("SoundPath");
                }
            }
        }



        string parameter;
        public string Parameter
        {
            get
            {
                return parameter;
            }
            set
            {
                if (parameter != value)
                {
                    parameter = value;
                    RaisePropertyChanged("Parameter");
                }
            }
        }

        List<DayOfWeek> days = new List<DayOfWeek>();
        public List<DayOfWeek> Days
        {
            get
            {
                return days;
            }
            set
            {
                if (days != value)
                {
                    days = value;
                    RaisePropertyChanged("Days");
                }
            }
        }


        private void RecieveAndApplyAlarm(AlarmEditingMessage message)
        {
            alarm = message.Alarm;

            if (alarm == null)
            {
                alarm = new Alarm();
                Title = "ADDING";
            }

            else
            {
                Hours = alarm.ScheduleTime.Hours;
                Minutes = alarm.ScheduleTime.Minutes;
                Seconds = alarm.ScheduleTime.Seconds;
                Message = alarm.Message;
                Parameter = alarm.Message.Parameter;
                Days = alarm.Days;
                Title = "EDITING";
            }
        }

        public RelayCommand<DayOfWeek> AddDayCommand { get; set; }
        private void AddDay(DayOfWeek parameter)
        {
            days.Add(parameter);
        }

        public RelayCommand<DayOfWeek> RemoveDayCommand { get; set; }
        private void RemoveDay(DayOfWeek parameter)
        {
            days.Remove(parameter);
        }

        public RelayCommand ConfirmCommand { get; set; }
        private void Confirm()
        {
            alarm.IsEnabled = true;
            alarm.ScheduleTime = new TimeSpan(Hours, Minutes, Seconds);

            Message = options[SelectedOption];
            if (Message.GetType() == typeof(SoundMessage))
                Parameter = SoundPath;
            if (Message.GetType() == typeof(TextMessage))
                Parameter = TextMessage;

            alarm.Message = Message;
            alarm.Message.Parameter = Parameter;
            alarm.Days = Days;

            if (Title == "ADDING")
            {
                alarm.Create();
                AlarmRepository.Content.Add(alarm);
            }

            MessengerInstance.Send(new CloseEditWindowMessage());
        }

    }
}
