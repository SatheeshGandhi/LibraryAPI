//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Language { get; set; }
        public int AvailableCopies { get; set; }
        public int Price { get; set; }
        public int IsActive { get; set; }
    }
}