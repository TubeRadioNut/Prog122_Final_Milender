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
using System.Windows.Shapes;

namespace Prog122_Final_Milender
{
    /// <summary>
    /// Interaction logic for AddArt.xaml
    /// </summary>
    public partial class AddArt : Window
    {
        public AddArt()
        {
            InitializeComponent();//Don't delete this and keep at the top of AddArt()


        }//End of AddArt()

        private void btnOpenMainWindow_Click(object sender, RoutedEventArgs e)
        {
            //I had to do some research to figure out how to test if MainWindow is open or not, this is what I cam up with and it seems to work 
            //Create bool varaible and assign it the result of Application class > Current List of windows > MainWindow open is equal to null
            bool displayArtWindowIsOpen = Application.Current.MainWindow == null;
            //Test if MainWindow is open using if/else with bool variable
            if (displayArtWindowIsOpen)
            {
                //Create instance of main window and open it with Show() method
                new MainWindow().Show();
            }
            //Infor user that Mainwindow is open already with MessageBox.Show() method
            else
            {
                MessageBox.Show("Display Art Window is already open");
            }
        }
    }//End class 
}//End namespace
