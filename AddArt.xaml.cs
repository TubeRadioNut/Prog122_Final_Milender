using Microsoft.Win32;
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
            FillComboBox();
            cmbDate.SelectedIndex = cmbDate.Items.Count -1;


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

        private void btnAddArt_Click(object sender, RoutedEventArgs e)
        {
            string artName = txtArtName.Text;
            int date = int.Parse(cmbDate.Text);
            string artist = txtArtist.Text;
            string information = runInformation.Text;
            Art.Styles style = GetStyle();
            string filePath = txtFilePath.Text;
            if(artName.Length > 0 && artist.Length > 0 && information.Length > 0 && filePath.Length > 0)
            {
                Art newArt = new Art(artName,date,artist,information,filePath,style);
                Data.AddArt(newArt);
                txtArtName.Text = "";
                txtArtist.Text = "";
                runInformation.Text = "";
                txtFilePath.Text = "";
                rbCubism.IsChecked = true;
                imgArtWork.Source = null;
            }
            else
            {
                MessageBox.Show("Make sure all information is filled out");
            }
        }

        public Art.Styles GetStyle()
        {
            if (rbRealism.IsChecked == true)
            {
                return Art.Styles.Realism;
            }
            else if (rbSurrealism.IsChecked == true)
            {
                return Art.Styles.Surrealism;
            }
            else if (rbFresco.IsChecked == true)
            {
                return Art.Styles.Fresco;
            }
            else if(rbGothic.IsChecked == true)
            {
                return Art.Styles.Gothic;
            }
            else if(rbFauvism.IsChecked == true)
            {
                return Art.Styles.Fauvism;
            }
            return Art.Styles.Cubism;
        }

        public void FillComboBox()
        {

            for (int i = 1000; i < 2025; i++)
            {
                cmbDate.Items.Add(i);
            }
        }

        private void btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            //Create an instance of OpenFileDialog and name is filePicker
            OpenFileDialog filePicker = new OpenFileDialog();
            //Filter by format
            filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg; *webp";
            //Test if user picked a file and said ok with if statement
            if (filePicker.ShowDialog() == true)
            {
                string filePath = filePicker.FileName;
                txtFilePath.Text = filePath;
                BitmapImage newImage = Art.GenerateBitMap(filePath);
                imgArtWork.Source = newImage;
            }
        }
    }//End class 
}//End namespace
