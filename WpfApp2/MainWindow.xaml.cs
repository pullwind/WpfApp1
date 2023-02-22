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

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void bt_test(object sender, RoutedEventArgs e)
		{

			//var str1 = @"Microsoft Windows Desktop Runtime -7.0.0(x86)---- fire";
			//var str2 = tb_appName.Text;

			//if(str1.Contains(str2,StringComparison.OrdinalIgnoreCase))
			//{
			//	MessageBox.Show("yes, found str2 in str1");
			//}
			//else
			//{
			//	MessageBox.Show("no found");
			//}
			//return;

            var listOfRegEntry = new List<string>();
			var appList = PCinfoClass.getListApp(tb_appName.Text, listOfRegEntry);
			lb_installedAppInOS.ItemsSource = appList;
			lb_installedAppInSubkeyOfRegestry.ItemsSource = listOfRegEntry;


			if(appList != null )
			{
				if(appList.Count > 0)
				{
					MessageBox.Show("found installed app list");
				}
				else
				{
                    MessageBox.Show("no found installed app of target name");
                }

			}

            if (listOfRegEntry != null)
            {
                if (listOfRegEntry.Count > 0)
                {
                    MessageBox.Show("found installed app of Reg entry");
                }
                else
                {
                    MessageBox.Show("no found installed app of target name of Reg entry");
                }

            }

        }
    }
}
