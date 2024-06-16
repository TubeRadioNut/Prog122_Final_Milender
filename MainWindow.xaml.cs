//Charles Milender
//6-8-2024
//Programming 122
//Final
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
        public bool stopForLoop = false;
        public MainWindow()
        {
            InitializeComponent();//<---Don't delete this and keep at the top of MainWindow()
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
            Art selectedArt = lvArt.SelectedItem as Art;
            if(selectedArt != null)
            {
                rtbArt.Document = selectedArt.FormattedArtworkPost();
                imgArt.Source = selectedArt.Image;
            }
        }

        private async void btnOpenSideShow_Click(object sender, RoutedEventArgs e)
        {
            cnvSlideShow.Visibility = Visibility.Visible;
            for(int i = 0; Data.Artworks.Count > i && !stopForLoop; i++)
            {
                imgSlideShow.Source = Data.Artworks[i].Image;
                await Task.Delay(5000);
            }
            cnvSlideShow.Visibility = Visibility.Hidden;
        }

        private void btnCloseSlideShow_Click(object sender, RoutedEventArgs e)
        {
            stopForLoop = true;
            cnvSlideShow.Visibility= Visibility.Hidden;
        }
    }//End Class
}//End namespace