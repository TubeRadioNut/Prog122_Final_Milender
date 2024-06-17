//Charles Milender
//6-8-2024
//Programming 122
//Final - Art Blog - S24
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog122_Final_Milender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creaate a bool variable and assign it to be false
        public bool stopForLoop = false;
        public MainWindow()
        {
            InitializeComponent();//<---Don't delete this and keep at the top of MainWindow()
            //Assign List View the ObservableCollection of Art
            lvArt.ItemsSource = Data.Artworks;

        }//End MainWindow

        private void btnAddArt_Click(object sender, RoutedEventArgs e)
        {
            //Creat bool variable and assign it the result of Class Application > Current  > list of windows > enum OfType > enum FirstOrDefaut is equal to null
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
            //Create an Art variable and assign it the Art that is selected in List View
            Art selectedArt = lvArt.SelectedItem as Art;
            //test if an Art is selected from the List View
            if(selectedArt != null)
            {
                //Assign the Rich Text Box Document the formatted FlowDocument from the Selected Art in List View
                rtbArt.Document = selectedArt.FormattedArtworkPost();
                //Assign the image source to the Image from selected Art in the List View
                imgArt.Source = selectedArt.Image;
            }
        }
        //Create Slide Show
        private async void btnOpenSideShow_Click(object sender, RoutedEventArgs e)
        {
            //Change visibility of canvas to visisble
            cnvSlideShow.Visibility = Visibility.Visible;
            //Loop through Art in the OberservableCollection from the Data class, loop will end when either all Images have been shown, or bool is true
            for(int i = 0; Data.Artworks.Count > i && !stopForLoop; i++)
            {
                //Assign image source to image to current index of ObservableCollection Image
                imgSlideShow.Source = Data.Artworks[i].Image;
                //I had to research this, and found this on SubStack, it creates a delay
                //Create a five second delay 
                await Task.Delay(5000);
            }
            //Change visibility of canvas to hidden after slide is done, or has been closed
            cnvSlideShow.Visibility = Visibility.Hidden;
        }
        //Create button click method to stop the slide show
        private void btnCloseSlideShow_Click(object sender, RoutedEventArgs e)
        {
            //Assign bool to true
            stopForLoop = true;
            //Change canvas visibility to hidden
            cnvSlideShow.Visibility= Visibility.Hidden;
        }
        //Create a button click method to open EditArt window
        private void btnOpenEditArt_Click(object sender, RoutedEventArgs e)
        {
            //Create a bool and assign it the result to Class Application > list of Windows > OfType EditArt > first or default EditArt window in the collection and assign it null
            bool editArtWindowIsOpen = Application.Current.Windows.OfType<EditArt>().FirstOrDefault() == null;
            //Test if EditArt Window is open with bool variable
            if(editArtWindowIsOpen)
            {
                //If window is not open, open it
                new EditArt().Show();
            }
            //Inform user the EditArt window is already open with messagebox Show() method
            else
            {
                MessageBox.Show("Edit Art Window is already open");
            }
        }
    }//End Class
}//End namespace