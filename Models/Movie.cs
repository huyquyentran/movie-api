using System;

namespace MovieApp.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}