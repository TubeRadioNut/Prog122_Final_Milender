using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog122_Final_Milender
{
    public static class Data
    {
        //Fields
        static ObservableCollection<Art> _artworks;

        //Constructor
        static Data()
        {
            _artworks = new ObservableCollection<Art>();
        }

        //Properties
        public static ObservableCollection<Art> Artworks { get => _artworks; }

        //Methods
        public static void AddArt(Art art)
        {
            _artworks.Add(art);
        }
    }//End class

}//End namespace
