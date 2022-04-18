using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
using System.Media;
using Plugin.SimpleAudioPlayer;

namespace application
{

    public partial class MainWindow : Window
    {
        
        static int numberOfClms = 24;
        static public int numberOfRaws = 8;


        int y = -1;
        public static Column[] columns = new Column[numberOfClms];

        public static MediaPlayer[] tracks = new MediaPlayer[numberOfRaws];

        public DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }
        private static int x = numberOfClms - 1;        
        private static int raw;
        public void init(object sender, EventArgs e)
        {
            for (int i = 0; i < numberOfRaws; i++)
            {
                
                tracks[i] = new MediaPlayer();
                tracks[i].Volume = 0;
                tracks[i].Open(new Uri(@$"C:\Samples\{i+1}.mp3"));
               
            }
            {
                tracks[0].Volume = 1;
                tracks[1].Volume = 1;
                tracks[2].Volume = 1;
                tracks[3].Volume = 1;
                tracks[4].Volume = 1;
                tracks[5].Volume = 1;
                tracks[6].Volume = 1;
                tracks[7].Volume = 1;
            }
            HeadStack.Background = new SolidColorBrush(Colors.White);
            Temp.Text = "120";
            for (int i = 0; i < numberOfClms; i++)
            {
                Column column = new Column(i);
                TrackStack.Children.Add(column);
                column.MouseRightButtonDown += new MouseButtonEventHandler(bordered);
                columns[i] = column;
            }
            
            timer =new DispatcherTimer();
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 60000 / Convert.ToInt32(Temp.Text));

            timer.Tick += new EventHandler(Tick);
            
            
        }

        public static void bordered(object sender, MouseButtonEventArgs e)
        {
            Column clm = sender as Column;
            x = clm.border;
            for (int i = 0; i <= x; i++)
                columns[i].On();
            for (int i = x + 1; i < numberOfClms; i++)
                columns[i].Off();
        }



        public void Tick(object sender, EventArgs e)
        {
            if (y >= x)
                y = 0;
            else
                y++;

            Slider.Margin = new Thickness(33 * y, 105, 770 - 33 * y, 0);
            for (int i = 0; i < numberOfRaws; i++)
                {
                    if ((bool)columns[y].column[i].IsChecked)
                    {
                        tracks[i].Position = TimeSpan.Zero;
                        tracks[i].Play();                        
                    }
                }
            

        }

        private void Play(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                Slider.Visibility = Visibility.Hidden;
                Temp.IsReadOnly = false;
            }
            else
            {
                Temp.IsReadOnly = true;
                y = 0;
                Slider.Visibility = Visibility.Visible;
                timer.Start();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 60000 / Convert.ToInt32(Temp.Text));
            }
        }

    }
}

