using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadEmail.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Attachement { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}