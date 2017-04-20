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
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System.Windows.Controls.Primitives;
using FlaterceClocks.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace FlaterceClocks.View
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : MetroWindow
    {
        public EditWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseEditWindowMessage>(this, CloseHandler);
        }

        private void CloseHandler(CloseEditWindowMessage message)
        {
            this.Close();
        }

        const int H_MAX = 23;
        const int M_MAX = 59;
        const int S_MAX = 59;

        private void hoursTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            if (!int.TryParse(hoursTextBox.Text, out n))
            {
                if (hoursTextBox.Text == "")
                {
                    return;
                }

                MessageBox.Show("This field can only contain numbers!");
                hoursTextBox.Text = "0";
            }
            else
            {
                if(n > H_MAX)
                {
                    hoursTextBox.Text = H_MAX.ToString();
                }
            }
        }

        private void minutesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            if (!int.TryParse(minutesTextBox.Text, out n))
            {
                if (minutesTextBox.Text == "")
                {
                    return;
                }

                MessageBox.Show("This field can only contain numbers!");
                minutesTextBox.Text = "0";
            }
            else
            {
                if (n > M_MAX)
                {
                    minutesTextBox.Text = M_MAX.ToString();
                }
            }
        }

        private void secondsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            if (!int.TryParse(secondsTextBox.Text, out n))
            {
                if (secondsTextBox.Text == "")
                {
                    return;
                }

                MessageBox.Show("This field can only contain numbers!");
                secondsTextBox.Text = "0";
            }
            else
            {
                if (n > S_MAX)
                {
                    secondsTextBox.Text = S_MAX.ToString();
                }
            }
        }

        private void DayToggleButton_Checked(object sender, EventArgs e)
        {
            ((EditViewModel)DataContext).AddDayCommand.Execute((DayOfWeek) Int32.Parse(((string)(sender as ToggleButton).Tag)));
        }

        private void DayToggleButton_UnChecked(object sender, EventArgs e)
        {
            ((EditViewModel)DataContext).RemoveDayCommand.Execute((DayOfWeek)Int32.Parse(((string)(sender as ToggleButton).Tag)));
        }
    }
}
