using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }
        [Required]
        public string Shelf { get; set; }
        public bool IsAvailable { get; set; }
    }
}