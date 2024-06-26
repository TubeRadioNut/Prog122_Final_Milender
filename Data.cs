﻿using System;
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
        //Create a new instance of ObservableCollection and name it _artwork
        static ObservableCollection<Art> _artworks;

        //Constructor
        static Data()
        {
            //Initialize the ObservableCollection
            _artworks = new ObservableCollection<Art>(); 
            //Create test Art and add it to the ObservableCollection using the AddArt method
            //Art newArt = new Art("Grade Book", 2020, "Walter Waterman", "Class room situation", "C:\\Users\\rt65s\\Documents\\Software II\\Week 11\\Prog122_Final_Milender\\Images\\ReportCard_2.jpeg", Art.Styles.Realism);
            //AddArt(newArt);
        }

        //Properties
        public static ObservableCollection<Art> Artworks { get => _artworks; }

        //Methods
        //Create method to Add Art to the ObservableCollection
        public static void AddArt(Art art)
        {
            _artworks.Add(art);
        }
    }//End class

}//End namespace
