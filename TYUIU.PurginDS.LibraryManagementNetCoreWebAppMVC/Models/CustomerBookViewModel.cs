using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Models
{
    public class CustomerBookViewModel
    {
        public Customer Customer { get; set; }
        public List<BookViewModel> Books { get; set; }
        public List<BorrowHistory> BorrowHistories { get; set; }
    }
}