using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Streams.Models
{
    public class Movie
    {

        public int Id { get; set; }
        
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name= "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Require]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        [Require]
        public byte GenreId { get; set; }//Convension/Foreign key

        //Navigation Property
        //Allows navigation from one type to another
        //loade an object and its related object from the database
        public Genre Genre { get; set; }

       
       
    }
}