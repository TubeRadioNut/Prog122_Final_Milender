using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Prog122_Final_Milender
{
    public class Art
    {
        //Fields
        public enum Styles { Realism, Surrealism, Fresco, Gothic, Fauvism, Cubism}
        string _name;
        int _date;
        string _artist;
        string _information;
        string _filePath;
        Styles _styles;
        BitmapImage _image;

        //Constructor
        public Art(string name, int date,string artist, string informaion, string filePath, Styles styles)
        {
            _name = name;
            _date = date;
            _artist = artist;
            _information = informaion;
            _filePath = filePath;
            _styles = styles;
            _image = GenerateBitMap(_filePath);
        }

        //Properties
        public string Name { get => _name; set => _name = value; }
        public int Date { get => _date; set => _date = value; }
        public string Artist { get => _artist; set => _artist = value; }
        public string Information { get => _information; set => _information = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public Styles Styles1 { get => _styles; set => _styles = value; }
        public BitmapImage Image { get => _image; set => _image = value; }


        //Methods
        //Create method that returns a BitmapImage and takes a string in its parameters -> to convert filePath string to BitmapImage
        public static BitmapImage GenerateBitMap(string filePath)
        {
            Uri convertFilePath = new Uri(filePath);
            BitmapImage bitmap = new BitmapImage(convertFilePath);
            return bitmap;
        }

        //Create a method that returns a formatted FlowDocument for a Rich Text Box
        public FlowDocument FormattedArtworkPost()
        {
            FlowDocument fullDoc = new FlowDocument();
            fullDoc.Blocks.Add(Date_Formatted());
            fullDoc.Blocks.Add(Nmae_Formatted());
            fullDoc.Blocks.Add(Artist_Formatted())
;           fullDoc.Blocks.Add(Information_Formatted());
            fullDoc.Blocks.Add(Styles_Formatted());
            fullDoc.FontFamily = new FontFamily("Arial");
            return fullDoc;
        }
        //Create a method that returns a formatted Paragraph for date
        private Paragraph Date_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_date.ToString());
            run.FontSize = 10;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);
            return para;
        }
        //Create a method that returns a formatted Paragraph for name
        private Paragraph Nmae_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_name);
            run.FontSize = 26;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);
            return para;
        }
        //Create a method that returns a formatted Peragraph for artist
        private Paragraph Artist_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_artist);
            run.FontSize = 18;
            run.FontStyle = FontStyles.Oblique;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);
            return para;
        }
        //Create a method that returns a formatted Paragraph for information
        private Paragraph Information_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_information);
            run.FontSize = 12;
            run.FontStyle = FontStyles.Italic;
            para.Inlines.Add(run);
            return para;
        }
        //Create a method that returns a formatted Paragraph for styles
        private Paragraph Styles_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_styles.ToString());
            run.FontSize = 16;
            run.TextDecorations = TextDecorations.Underline;
            para.Inlines.Add(run);
            return para;
        }


    }//End class

}//End namespace
