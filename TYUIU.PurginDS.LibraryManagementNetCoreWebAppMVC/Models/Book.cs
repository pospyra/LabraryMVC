using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        [Required]
        public string Shelf { get; set; }
        public ICollection<BorrowHistory> BorrowHistories { get; set; }
    }
}