using Roo.Data;

namespace Whats.Web.SoftWare.Models
{   
    [DataObject("ContactMessage","CMID")]
    public class ContactMessage
    {
        [DataField("NVARCHAR(50)")]
        public string CMID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Name { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Phone { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Email { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Company { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Title { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Content { get; set; }
    }
}