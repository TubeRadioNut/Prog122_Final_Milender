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
            //Call the FillComboBox methos to create a list of dates for the combobox
            FillComboBox();
            //Set combox selected index to the last date generated
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
        //Create button click method that adds art to ObservableCollection of Art using the input fields
        private void btnAddArt_Click(object sender, RoutedEventArgs e)
        {
            //Create variables and assign the data from the input fields
            string artName = txtArtName.Text;
            int date = int.Parse(cmbDate.Text);
            string artist = txtArtist.Text;
            string information = runInformation.Text;
            Art.Styles style = GetStyle();
            string filePath = txtFilePath.Text;
            //Test if artName text box is not empty & artist text box is not empty & information run is not empty & filePath text box is not empty
            if(artName.Length > 0 && artist.Length > 0 && information.Length > 0 && filePath.Length > 0)
            {
                //Create a new instance of art and assign it data from input fields
                Art newArt = new Art(artName,date,artist,information,filePath,style);
                //Add Art to ObservableCollection of Art using the AddArt method from the Data class
                Data.AddArt(newArt);
                //Clear input fields
                txtArtName.Text = "";
                txtArtist.Text = "";
                runInformation.Text = "";
                txtFilePath.Text = "";
                //Make radio button for Cubism checked
                rbCubism.IsChecked = true;
                //Clear image source
                imgArtWork.Source = null;
            }
            //Inform user one or all text boxes and rich text box is empty
            else
            {
                MessageBox.Show("Make sure all information is filled out");
            }
        }
        //Create method that returns an Art Style (emnum)
        public Art.Styles GetStyle()
        {
            //test which if any radio button is check then return that style(emnum)
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
            //Default radio button it is checked by default
            return Art.Styles.Cubism;
        }
        //Create metod to generate Dates for the combobox
        public void FillComboBox()
        {
            //Create a new instace of DateTime variable
            DateTime currentDate = DateTime.Now;
            //Create int and assign it the current year plus 1
            int currentYear = currentDate.Year + 1;
            //MessageBox.Show($"{currentYear}");
            //Create Dates for combobox starting at 1000 and ending at currentYear
            for (int i = 1000; i < currentYear; i++)
            {
                //Add int variable value to combobox Items
                cmbDate.Items.Add(i);
            }
        }
        //create button click method for ImagePath button
        private void btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            //Create an instance of OpenFileDialog and name is filePicker
            OpenFileDialog filePicker = new OpenFileDialog();
            //Filter by format
            filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg; *webp";
            //Test if user picked a file and said ok with if statement
            if (filePicker.ShowDialog() == true)
            {
                //Create string vaiable and assign it the FilePathName from the open dialog box
                string filePath = filePicker.FileName;
                //assign FilePath textbox string variable
                txtFilePath.Text = filePath;
                //Create a bitmapimage variable and assign it the result of the GenerateBitMap method from the Data class passing string variable to it
                BitmapImage newImage = Art.GenerateBitMap(filePath);
                //Assign image source to bitmapimage variable
                imgArtWork.Source = newImage;
            }
        }
    }//End class 
}//End namespace
