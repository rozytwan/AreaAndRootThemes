using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenimSACCOS.Models
{
    public class Gallery
    {

        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public IEnumerable<string> Images { get; set; }

    }
}