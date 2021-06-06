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

namespace WpfControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AnalogClock2 : UserControl
    {
        public AnalogClock2()
        {
            InitializeComponent();
        }

        public void SetTime(int hours, int minutes, int seconds, int milliseconds=0)
        {
            SetSeconds(seconds + (double)milliseconds / 1000);
            SetMinutes(minutes);
            SetHours(hours);
        }

        public void SetTime(TimeSpan time) => SetTime(time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

        public void SetTime(DateTime dateTime) => SetTime(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

        private void SetHours(int hours)
        {
            if (hours > 24 || hours < 0)
                throw new Exception("Часы не могут быть больше 24 и меньше 0");

            RotateTransform transform = (RotateTransform)hourGrid.RenderTransform;
            transform.Angle = hours * 30;
        }

        private void SetMinutes(int minutes)
        {
            if (minutes > 60 || minutes < 0)
                throw new Exception("Минуты не могут быть больше 60 и меньше 0");

            RotateTransform transform = (RotateTransform)minuteGrid.RenderTransform;
            transform.Angle = minutes * 6;
        }

        private void SetSeconds(double seconds) 
        {
            if (seconds > 60 || seconds < 0)
                throw new Exception("Секунды не могут быть больше 60 и меньше 0");

            RotateTransform transform = (RotateTransform)secondGrid.RenderTransform;
            transform.Angle = seconds * 6;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > Width)
                Width = Height;
            else Height = Width;

            secondRectangle.Width = Width / 200 * 1;
            minuteRectangle.Width = Width / 200 * 2.5;
            hourRectangle.Width = Width / 200 * 3.5;
        }
    }
}