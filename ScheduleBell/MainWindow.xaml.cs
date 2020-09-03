using System;
using System.Timers;
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

namespace ScheduleBell
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var screen = System.Windows.SystemParameters.WorkArea;
            this.Left = screen.Right - this.Width;
            this.Top = 0;

            DateTime time = DateTime.Now;
            cloc.Text = time.ToString();

            System.Timers.Timer timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SetClock);
            timer.Start();
        }

        private void SetClock(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { cloc.Text = DateTime.Now.ToString(); }));
        }

        private void Window_Drag(object sender, MouseEventArgs e)
        {
            this.DragMove();
            sche.Text = "test";
        }

        private void MissionBar_Click(object sender, RoutedEventArgs e)
        {
            int done = Convert.ToInt32((sender as Button).Tag);
            if (done == 0)
            {
                (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0x55, 0xFF, 0x55));
                (sender as Button).Tag = 1;
            }
            else
            {
                list.Children.Remove(sender as Button);
            }
        }

        private void AddMissionBar()
        {
            string name = MissionName.Text;
            MissionName.Text = "";

            Button btn = new Button
            {
                Content = name,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = 36,
                Width = 220,
                Background = new SolidColorBrush(Color.FromRgb(0xFF, 0x55, 0x55)),
                FontSize = 14,
                Tag = 0
            };
            btn.Click += MissionBar_Click;
            list.Children.Add(btn);
        }

        private void AddMissionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMissionBar();
        }
    }
}
