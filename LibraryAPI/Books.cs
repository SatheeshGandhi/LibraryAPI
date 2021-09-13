using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAPI
{
    public class Books
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Language { get; set; }
        public int AvailableCopies { get; set; }
        public int Price { get; set; }
        public int IsActive { get; set; }
    }
}