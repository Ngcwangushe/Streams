using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Streams.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
       
        public DateTime DateAdded { get; set; }
        
        public int NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        //Navigation Property
        //Allows navigation from one type to another
        //loade an object and its related object from the database
        public byte GenreId { get; set; }//Convension/Foreign key
        public GenreDto Genre { get; set; }
        

    }
}