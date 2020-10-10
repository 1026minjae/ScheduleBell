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
    
    public class Schedule
    {
        public bool isDate = false; //false: 요일 지정. true: 날짜 지정. 날짜 지정이 높은 우선순위.
        private int starthour = 0; //value: 0~23
        private int startmin = 0; //value: 0-59
        private int endhour = 0; //value:0~23
        private int endmin = 0; //value: 0-59
        public string sche;

        public Schedule(bool id, int sh, int sm, int eh, int em, string sch)
        {
            isDate = id;
            starthour = sh;
            startmin = sm;
            endhour = eh;
            endmin = em;
            sche = sch;
        }

        public bool IsTime(int currhour, int currmin)
        {
            if(starthour > currhour || currhour > endhour)
            {
                return false;
            }
            else if (starthour < currhour && currhour < endhour)
            {
                return false;
            }
            else if(starthour == currhour && startmin <= currmin)
            {
                return true;
            }
            else if(currhour == endhour && currmin <= endmin)
            {
                return true;
            }
            return true;
        }

        public bool IsEndTime(int currhour, int currmin)
        {
            if (currhour == endhour && currmin == endmin)
                return true;
            return false;
        }
    }

    public partial class MainWindow : Window
    {
        private List<Schedule> schedules = new List<Schedule>();
        private bool exist_sche = false;
        private int curr_sche_index = 0;

        private void ReadScheDB()
        {
            //현재 해당되는 일정을 DB에서 가져온다.
            //string query = "SELECT * FROM TABLE WHERE year=yyyy and month=mm and day=dd or dow=d;";
            //텍스트, 시작시점, 종료시점, 타입을 가져온다.
            //schedules 할당. 담는다.
            //하루마다 갱신한다.

            //DB에서부터 정렬된 데이터를 가지고 있다고 가정한다.
            //그냥 데이터를 추가하면 정렬 과정까지 한다고 치자.

            //sample
            //schedules.Add(new Schedule(false, 15, 0, 16, 0, "일정 테스트 용도입니다."));
            //schedules.Add(new Schedule(true, 14, 30, 15, 30, "날짜 지정 테스트 용도입니다."));
        }

        public MainWindow()
        {
            InitializeComponent();
            ReadScheDB();
        }

        private void SetClock(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate {
                cloc.Text = DateTime.Now.ToString();
            }));
        }

        private void SetSche(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate {
                //bool isDate = false; //날짜를 지정한 일정이 우선순위가 높으므로 이를 구분하기 위해 필요
                int currhour = DateTime.Now.Hour;
                int currmin = DateTime.Now.Minute;
                
                if(!exist_sche)
                {
                    if (schedules[curr_sche_index].IsTime(currhour, currmin))
                    {
                        sche.Text = schedules[curr_sche_index].sche;
                        exist_sche = true;
                    }
                }
                else if (schedules[curr_sche_index].IsEndTime(currhour, currmin))
                {
                    curr_sche_index++;
                    if (schedules[curr_sche_index].IsTime(currhour, currmin))
                    {
                        sche.Text = schedules[curr_sche_index].sche;
                    }
                    else
                    {
                        sche.Text = "일정이 없습니다.";
                        exist_sche = false;
                    }
                }
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var screen = System.Windows.SystemParameters.WorkArea;
            this.Left = screen.Right - this.Width;
            this.Top = 0;

            System.Timers.Timer timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SetClock);
            timer.Start();
            SetClock(sender, new EventArgs() as ElapsedEventArgs);

            if(schedules.Count > 0)
            {
                System.Timers.Timer timer2 = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
                timer2.AutoReset = true;
                timer2.Elapsed += new System.Timers.ElapsedEventHandler(SetSche);
                timer2.Start();
                SetSche(sender, new EventArgs() as ElapsedEventArgs);
            }
        }

        private void Window_Drag(object sender, MouseEventArgs e)
        {
            this.DragMove();

            var screen = System.Windows.SystemParameters.WorkArea;
            if (this.Left < 0)
            {
                this.Left = 0;
            }
            else if (this.Left > screen.Right - this.Width)
            {
                this.Left = screen.Right - this.Width;
            }
            if (this.Top > screen.Bottom - this.Height)
            {
                this.Top = screen.Bottom - this.Height;
            }
        }

        private void MissionBar_Click(object sender, RoutedEventArgs e)
        {
            int done = Convert.ToInt32((sender as Button).Tag);
            if (done == 0)
            {
                (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0xAA, 0xFF, 0xAA));
                (sender as Button).Tag = 1;
            }
            else
            {
                (sender as Button).Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xAA, 0xAA));
                (sender as Button).Tag = 0;
            }
        }

        private void MissionBar_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            list.Children.Remove(sender as Button);
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
                Height = 32,
                Width = 220,
                Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xAA, 0xAA)),
                FontSize = 14,
                Tag = 0
            };
            btn.Click += MissionBar_Click;
            btn.MouseDoubleClick += MissionBar_DoubleClick;
            list.Children.Add(btn);
        }

        private void MissionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddMissionBar();
            }
        }

        private void AddMissionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMissionBar();
        }

        private void reshow_Click(object sender, RoutedEventArgs e)
        {
            working.Visibility = Visibility.Visible;
            reshow.Visibility = Visibility.Hidden;

            var screen = System.Windows.SystemParameters.WorkArea;
            this.Left = screen.Right - this.Width;
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            working.Visibility = Visibility.Hidden;
            reshow.Visibility = Visibility.Visible;

            var screen = System.Windows.SystemParameters.WorkArea;
            this.Left = screen.Width - 70;
        }
    }
}
