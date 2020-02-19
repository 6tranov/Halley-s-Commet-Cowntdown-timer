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

namespace WpfApp8
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        DateTime NextAppearDate;
        public MainWindow()
        {
            InitializeComponent();
            NextAppearDate = new DateTime(2061, 7, 28);
            timer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(1),
                DispatcherPriority.SystemIdle,
                (sender, e) =>
                {
                    CurrentTimeLabel.Content = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss.ff");
                    var timeSpan = (NextAppearDate - DateTime.Now);
                    TimeSpanLabel.Content = timeSpan.ToString(@"d\日hh'時間'mm\分ss\.ff\秒");
                },
                Dispatcher.CurrentDispatcher
                );

            AppearDateLabel.Content = NextAppearDate.ToString("yyyy年MM月dd日");
            timer.Start();
        }
    }
}
