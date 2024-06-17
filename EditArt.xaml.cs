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
            lvArt.ItemsSource = Data.Artworks;
            FillComboBox();
            cmbEditDate.SelectedIndex = cmbEditDate.Items.Count - 1;
            CloseMainWindow();
        }//End EditArt


        public async void CloseMainWindow()
        {
            await Task.Delay(200);
            bool mainWindowIsOpen = Application.Current.MainWindow != null;
            if (mainWindowIsOpen)
            {
                Application.Current.MainWindow.Close();
            }

        }
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

        private void lvArt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if (selectedArt != null)
            {
                txtEditName.Text = selectedArt.Name;
                txtEditArtist.Text = selectedArt.Artist;
                runEditInformation.Text = selectedArt.Information;
                txtEditFilePath.Text = selectedArt.FilePath;
                imgEditImage.Source = selectedArt.Image;
                //This took me a while to figure out how get the combobox to change to date of the selectedArt,
                //but I did not find the answer online, I just figure it by trail and error
                //Get combobox to display the date from an artwork, the date starts at 1000, so artwork date minus 1000 gets the correct item (Date) to display
                cmbEditDate.SelectedIndex = selectedArt.Date - 1000;
                GetArtStyle();
            }
        }

        public void FillComboBox()
        {

            for (int i = 1000; i < 2025; i++)
            {
                cmbEditDate.Items.Add(i);
            }
        }

        public void GetArtStyle()
        {
            Art selectedArt = lvArt.SelectedItem as Art;
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

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if(selectedArt != null)
            {
                if(txtEditName.Text.Length > 0)
                {
                    selectedArt.Name = txtEditName.Text;
                    lvArt.Items.Refresh();
                }
                CloseMainWindow();
            }
            
        }

        private void btnEditDate_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if (selectedArt != null)
            {

                selectedArt.Date = int.Parse(cmbEditDate.Text);
                lvArt.Items.Refresh();
                CloseMainWindow();
            }
            
        }

        private void btnEditName_Copy_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if (selectedArt != null)
            {
                if (txtEditArtist.Text.Length > 0)
                {
                    selectedArt.Artist = txtEditArtist.Text;
                    lvArt.Items.Refresh();
                }
                CloseMainWindow();
            }
            
        }

        private void btnEditInformation_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if (selectedArt != null)
            {
                if (runEditInformation.Text.Length > 0)
                {
                    selectedArt.Information = runEditInformation.Text;
                    lvArt.Items.Refresh();
                }
                CloseMainWindow();
            }
            
        }

        private void btnEditFilePath_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;
            if (selectedArt != null)
            {
                //File Picker
                OpenFileDialog filePicker = new OpenFileDialog();
                filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg;*.webp;";

                if (filePicker.ShowDialog() == true)
                {
                    string filePath = filePicker.FileName;
                    txtEditFilePath.Text = filePath;

                    BitmapImage newImage = Art.GenerateBitMap(filePath);

                    imgEditImage.Source = newImage;
                    selectedArt.Image = newImage;
                    selectedArt.FilePath = filePath;

                    CloseMainWindow();
                }
            }
            
        }

        private void btnEditStyle_Click(object sender, RoutedEventArgs e)
        {
            Art selectedArt = lvArt.SelectedItem as Art;

            if(selectedArt != null)
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
                lvArt.Items.Refresh();
                CloseMainWindow();
            }
        }
    }//End class
}//End namespace
