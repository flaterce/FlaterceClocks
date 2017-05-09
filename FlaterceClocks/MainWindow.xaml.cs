using FlaterceClocks.Model;
using FlaterceClocks.View;
using FlaterceClocks.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FlaterceClocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            if (DateTime.Now <  new DateTime(2017, 5, 2))
                App.Current.Shutdown();

            InitializeComponent();
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();

            Messenger.Default.Register<OpenEditWindowMessage>(this, CreateEditWindow);
        }

        private void CreateEditWindow(OpenEditWindowMessage message)
        {
            EditWindow win = new EditWindow();
            win.Show();
            Messenger.Default.Send(new AlarmEditingMessage(message.Alarm));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            actualTimeTextBlock.Text = DateTime.Now.ToLongTimeString();
            dateTextBlock.Text = DateTime.Now.ToLongDateString();
        }
    }
}
