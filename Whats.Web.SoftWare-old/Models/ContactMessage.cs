using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whats.Web.SoftWare.Models
{
    public class ContactMessage
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}