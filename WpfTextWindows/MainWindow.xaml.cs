using System;
using System.Windows;
using System.Windows.Threading;
/// От создателей Славки КУдрина
namespace WpfTextWindows
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new()
            {
                Interval = TimeSpan.FromSeconds(0.6)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        readonly string hw = "Я генка!";
        int counter = 0;
        string temp = "";
        private void Timer_Tick(object? sender, EventArgs e)
        {
            temp += hw[counter];

            label1.Content = temp;

            counter++;
            if (counter == hw.Length)
            {
                counter = 0;
                temp = "";
            }
        }


        bool _canMove = false;
        Point _offsetPoint = new(0, 0);
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _canMove = true;

            _offsetPoint = e.MouseDevice.GetPosition(this);

            e.MouseDevice.Capture(this);
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_canMove == true)
            {
                Point p = e.MouseDevice.GetPosition(this);
                this.Left = PointToScreen(p).X - _offsetPoint.X;
                this.Top = PointToScreen(p).Y - _offsetPoint.Y;
            }
        }

        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _canMove = false;
            e.MouseDevice.Capture(null);
        }
    }
}
