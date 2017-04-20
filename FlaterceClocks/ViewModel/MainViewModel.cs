using FlaterceClocks.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace FlaterceClocks.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddCommand = new RelayCommand(Add);
        }

        public ObservableCollection<Alarm> Alarms
        {
            get
            {
                return AlarmRepository.Content;
            }
        }


        public RelayCommand AddCommand { get; set; }

        void Add()
        {
            MessengerInstance.Send(new OpenEditWindowMessage(null));
        }
    }
}