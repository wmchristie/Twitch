using System.Linq;
using System.Windows;
using Twitch.Core;

namespace Twitch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
/*
            var processes = Process.GetProcesses().Aggregate(new List<IntPtr>(), (memo, process) => {

                if (process.MainWindowHandle != (IntPtr)0 && process.MainWindowTitle.Trim().Length > 0)
                {
                    memo.Add(process.MainWindowHandle);
                }
                return memo;

            });

            var windowList = new WindowList(processes);
*/

            textBox1.Text = string.Join("\r\n", new TopLevelWindows().SelectMany(w => new[] {w.Title}
                .Concat(w.ChildWindows.Select(cw => cw.Title))).Where(t => !string.IsNullOrEmpty(t)));
        }

    }
}
