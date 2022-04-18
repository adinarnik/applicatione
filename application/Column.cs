using System;
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

namespace application
{
    public class Column : StackPanel

    {
        static int numberOfRaws = 8;
        private int Trackwidth = 33;
        private int Trackheight = 40;
        public CheckBox[] column = new CheckBox[numberOfRaws];
        public int border { get; }
        public static MediaPlayer[] tracks = new MediaPlayer[numberOfRaws];
        

        
        public Column(int x)
        {
            border = x;            
            this.Orientation = Orientation.Vertical;
            for (int i = 0; i < numberOfRaws; i++)
            {
                this.Background = new SolidColorBrush(Colors.White);
                CheckBox ck = new CheckBox();
                {
                    ck.Width = Trackwidth;
                    ck.Height = Trackheight;
                    ck.Margin = new Thickness(0, 0, 0, -4);
                    ck.VerticalAlignment = VerticalAlignment.Center;
                    ck.HorizontalAlignment = HorizontalAlignment.Center;
                    
                }
                column[i] = ck;
                this.Children.Add(ck);
            }            
        }
        public void Off()
        {
            for (int i = 0; i < column.Length; i++)
            {
                column[i].IsEnabled = false;
            }
        }
        public void On()
        {
            for (int i = 0; i < column.Length; i++)
            {
                column[i].IsEnabled = true;
            }
        }        
        public void Play()
        {
            
        }

    }
}
