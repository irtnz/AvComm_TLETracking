using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
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
using TLETracking;

namespace TLEInstall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TLETracking.RC4500Config config = new RC4500Config();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Grid_Loaded");
            //edit - caveat: if the user running the code does not have administrator rights, this will throw an exception.Since this is the case (and if the user will not have these rights) best practices should be to assume the log exists, and simply write to it.see: The source was not found, but some or all event logs could not be searched
    //        string myLog = "myNewLog";
    //        if (EventLog.Exists(myLog))
    //        {
    //            tbStatus.Text = ("Log '" + myLog + "' exists.");
    //        }
    //        else
    //        {
    //            tbStatus.Text = ("Log '" + myLog + "' does not exist.");
    //            if(!IsElevated)
    //            {
    //                tbStatus.Text += Environment.NewLine + Environment.NewLine + "********* Please re-run application as Administrator, to allow log to be created *********";
    //            }
    //        }

            if (!EventLog.SourceExists("AACL"))
            {
                EventSourceCreationData eventSourceData = new EventSourceCreationData("MyApplicationEventLog", "MyApplicationEventLog");
                EventLog.CreateEventSource(eventSourceData);
            }
        }

        static bool IsElevated
        {
            get
            {
                return WindowsIdentity.GetCurrent().Owner
                  .IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
            }
        }

        
    }
}
