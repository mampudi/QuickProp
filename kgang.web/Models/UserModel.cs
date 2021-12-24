using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace kgang.web.Models
{
    public class UserModel
    { 
        [DisplayName("Name")]
        public string Name { get; set; }
 
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string ImagePathBase64 { get; set; }
    }
}