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
using System.Timers;

namespace WpfControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AnalogClock : UserControl
    {

        TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0);

        public AnalogClock()
        {
            InitializeComponent();
            Timer timer = new Timer(10);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeSpan.Add(new TimeSpan(0, 0, 0, 0, 10));
            SetTime(timeSpan);
        }

        public void SetTime(int hours, int minutes, int seconds, int milliseconds=0)
        {
            SetSeconds(seconds, milliseconds);
            SetMinutes(minutes);
            SetHours(hours);
        }

        public void SetTime(TimeSpan time) => SetTime(time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

        public void SetTime(DateTime dateTime) => SetTime(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);


        private void SetHours(int hours)
        {
            if (hours > 24 || hours < 0)
                throw new Exception("„асы не могут быть больше 24 и меньше 0");

            RotateTransform transform = (RotateTransform)hourLine.RenderTransform;
            transform.Angle = hours * 15;
        }

        private void SetMinutes(int minutes)
        {
            if (minutes > 60 || minutes < 0)
                throw new Exception("ћинуты не могут быть больше 60 и меньше 0");

            RotateTransform transform = (RotateTransform)minuteLine.RenderTransform;
            transform.Angle = minutes * 6;

        }

        private void SetSeconds(int seconds, int milliseconds) 
        {
            if (seconds > 60 || seconds < 0)
                throw new Exception("—екунды не могут быть больше 60 и меньше 0");
            if (milliseconds < 0 || milliseconds > 1000)
                throw new Exception("ћиллисекунды не могут быть меньше 0 и больше 1000");

            double secMil = seconds + (double)milliseconds / 1000;

            RotateTransform transform = (RotateTransform)secondLine.RenderTransform;
            transform.Angle = secMil * 6;
        }


        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height > Width)
                Width = Height;
            else Height = Width;

            secondLine.X1 = Width / 2;
            secondLine.Y1 = Height / 20*11;
            secondLine.X2 = Width / 2;
            RotateTransform secondLineTransform = (RotateTransform)secondLine.RenderTransform;
            secondLineTransform.CenterX = Width / 2;
            secondLineTransform.CenterY = Height / 2;

            minuteLine.X1 = Width / 2;
            minuteLine.Y1 = Height / 2;
            minuteLine.X2 = Width / 2;
            minuteLine.Y2 = Height / 200 * 15;
            RotateTransform minuteLineTransform = (RotateTransform)minuteLine.RenderTransform;
            minuteLineTransform.CenterX = Width / 2;
            minuteLineTransform.CenterY = Height / 2;

            hourLine.X1 = Width / 2;
            hourLine.Y1 = Height / 2;
            hourLine.X2 = Width / 2;
            hourLine.Y2 = Height / 200 * 25;

            RotateTransform hourLineTransform = (RotateTransform)hourLine.RenderTransform;
            hourLineTransform.CenterX = Width / 2;
            hourLineTransform.CenterY = Height / 2;
        }
    }
}