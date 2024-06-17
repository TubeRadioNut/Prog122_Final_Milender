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
    /// Interaction logic for EditArt.xaml
    /// </summary>
    public partial class EditArt : Window
    {
        public EditArt()
        {
            InitializeComponent();//<--Don't delete this and keep at the top of EditArt()
            //Assign the list view the ObservableCollect from the Data class
            lvArt.ItemsSource = Data.Artworks;
            //Call the FillComboBox method to fill the combobox items with dates
            FillComboBox();
            //Set combobox selected indes to last created date
            cmbEditDate.SelectedIndex = cmbEditDate.Items.Count - 1;
            //Call the CloseMainWindow method to close the MainWindow, The Image in the MainWindow will not update after editing unless the List View source
            //is reassigned to a new instance of ObservableCollection, this seemed like easist way to update the listview in the MainWindow
            CloseMainWindow();
        }//End EditArt

        //Create method to close MainWindow, the async was automatic once I called the await Task
        public async void CloseMainWindow()
        {
            //Create a time delay of 2 milliseconds, any faster, the computer thinks the MainWiondow is open, not sure why, but this works
            await Task.Delay(200);
            //create bool variable and set it to the result of Application class> Current> MainWindow is not null, if MainWindow is closed and it is called
            //to close it will cause an exception, this seemed like an easy way to prevent that
            bool mainWindowIsOpen = Application.Current.MainWindow != null;
            //Test if MainWindow is open or not
            if (mainWindowIsOpen)
            {
                //Close MainWindow the Close method
                Application.Current.MainWindow.Close();
            }

        }
        //Create button click method to Open the MianWindow
        private void btnOpenDisplayArt_Click(object sender, RoutedEventArgs e)
        {
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
        //Create button click method to open the AddArt Window
        private void btnOpenAddArt_Click(object sender, RoutedEventArgs e)
        {
            //Create bool variable and assign it the result of Class Application > Current  > list of windows > enum OfType > enum FirstOrDefaut is equal to null
            bool addArtWindowIsOpen = Application.Current.Windows.OfType<AddArt>().FirstOrDefault() == null;
            //Test if AddArt window is open using if/else using bool variable
            if (addArtWindowIsOpen)
            {
                //Create instance of AddArt window and open it with Show() method
                new AddArt().Show();
            }
            //inform user Add Art windwo is open already with MessageBox.Show() method
            else
            {
                MessageBox.Show("Add Art Window is already open");
            }
        }
        //Create click mehtod for selecting an Art in the List View
        private void lvArt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //create a new instance of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //Fill input fields with info from the selected Art from the List View
                txtEditName.Text = selectedArt.Name;
                txtEditArtist.Text = selectedArt.Artist;
                runEditInformation.Text = selectedArt.Information;
                txtEditFilePath.Text = selectedArt.FilePath;
                //Set image source to selected Art from the List View
                imgEditImage.Source = selectedArt.Image;
                //This took me a while to figure out how get the combobox to change to date of the selectedArt,
                //but I did not find the answer online, I just figure it by trail and error
                //Get combobox to display the date from an artwork, the date starts at 1000, so artwork date minus 1000 gets the correct item (Date) to display
                cmbEditDate.SelectedIndex = selectedArt.Date - 1000;
                //Call the get style method to check radioi button of the style from the selected Art from the List View
                GetArtStyle();
            }
        }
        //Create method to generate Dates for the combobox
        public void FillComboBox()
        {
            //Create a new instace of DateTime variable
            DateTime currentDate = DateTime.Now;
            //Create int and assign it the current year plus 1
            int currentYear = currentDate.Year + 1;
            //Use for loop to generate years and max year to current year
            for (int i = 1000; i < currentYear; i++)
            {
                //Add int value to comobobox items
                cmbEditDate.Items.Add(i);
            }
        }
        //Create GetArtStyle method
        public void GetArtStyle()
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test what style is from selected Art from the List View and set Radio Button of that style to checked
            if (selectedArt.Styles1 == Art.Styles.Realism)
            {
                rbEditRealiam.IsChecked = true;
            }
            else if(selectedArt.Styles1 == Art.Styles.Surrealism)
            {
                rbEditSurrealism.IsChecked = true;
            }
            else if(selectedArt.Styles1 == Art.Styles.Fresco)
            {
                rbEditFresco.IsChecked = true;
            }
            else if(selectedArt.Styles1 == Art.Styles.Gothic)
            {
                rbEditGothic.IsChecked = true;
            }
            else if(selectedArt.Styles1 == Art.Styles.Fauvism)
            {
                rbEditFauvism.IsChecked = true;
            }
            else if(selectedArt.Styles1 == Art.Styles.Cubism)
            {
                rbEditCubism.IsChecked = true;
            }
        }
        //Create button click method for EditName button
        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //Test if EditName text box is empty
                if(txtEditName.Text.Length > 0)
                {
                    //reassign selected Art's name from List View
                    selectedArt.Name = txtEditName.Text;
                    //Refresh the List View with updated information
                    lvArt.Items.Refresh();
                }
                //close the MainWindow if it is open
                CloseMainWindow();
            }
            
        }
        //Create button click method for EditDate button
        private void btnEditDate_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //reassign selected Art's date from the List View
                selectedArt.Date = int.Parse(cmbEditDate.Text);
                //Refresh List View with updated information
                lvArt.Items.Refresh();
                //Close MainWindow if it is open
                CloseMainWindow();
            }
            
        }

        private void btnEditArtist_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //Test if text box EditArt is empty
                if (txtEditArtist.Text.Length > 0)
                {
                    //Reassign selected Art's Artist from the List View
                    selectedArt.Artist = txtEditArtist.Text;
                    //Refresh List View with updated information
                    lvArt.Items.Refresh();
                }
                //Close MainWindow if it is open
                CloseMainWindow();
            }
            
        }

        private void btnEditInformation_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //Test if Rich Text Box run is empty
                if (runEditInformation.Text.Length > 0)
                {
                    //Reassign selected Art's Information from the List View
                    selectedArt.Information = runEditInformation.Text;
                    //refresh List View with updated information
                    lvArt.Items.Refresh();
                }
                //Close MainWindow if it is open
                CloseMainWindow();
            }
            
        }

        private void btnEditFilePath_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                //File Picker
                //Create an instance of OpenFileDialog and name is filePicker
                OpenFileDialog filePicker = new OpenFileDialog();
                //Filter by format
                filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg;*.webp;";
                //Test if user picked a file and said ok with if statement
                if (filePicker.ShowDialog() == true)
                {
                    //Create string vaiable and assign it the FilePathName from the open dialog box
                    string filePath = filePicker.FileName;
                    //assign FilePath textbox string variable
                    txtEditFilePath.Text = filePath;
                    //Create a bitmapimage variable and assign it the result of the GenerateBitMap method from the Data class passing string variable to it
                    BitmapImage newImage = Art.GenerateBitMap(filePath);
                    //Assign image source to bitmapimage variable
                    imgEditImage.Source = newImage;
                    //Reassign selected Art's image from the List View
                    selectedArt.Image = newImage;
                    //Reassign selected Art's filePath from List View
                    selectedArt.FilePath = filePath;
                    //Close MainWindow if it is open
                    CloseMainWindow();
                }
            }
            
        }

        private void btnEditStyle_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instace of Art and assign it the selected Art from the List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //Test if an Art has been selected from the List View
            if (selectedArt != null)
            {
                if(rbEditRealiam.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Realism;
                }
                else if(rbEditSurrealism.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Surrealism;
                }
                else if(rbEditFresco.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Fresco;
                }
                else if(rbEditGothic.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Gothic;
                }
                else if(rbEditFauvism.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Fauvism;
                }
                else if(rbEditCubism.IsChecked == true)
                {
                    selectedArt.Styles1 = Art.Styles.Cubism;
                }
                //Reassign selected Art's Information from the List View
                lvArt.Items.Refresh();
                //Close MainWindow if it is open
                CloseMainWindow();
            }
        }
    }//End class
}//End namespace
