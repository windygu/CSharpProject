using Roo.Data;
using System;

namespace FreeRoo
{
    /// <summary>
    /// 文章模型
    /// </summary>
    [DataObject("Article", "ArticleID")]
    public class Article
    {
        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string ArticleID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string AName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string AHtml { get; set; }

        [DataField("NVARCHAR(50)")]
        public string ATitle { get; set; }

        [DataField("NVARCHAR(50)")]
        public string AAuthor { get; set; }

        [DataField("DATETIME")]
        public DateTime ATime { get; set; }

        [DataField("NVARCHAR(50)")]
        public string AContent { get; set; }

        [DataField("NVARCHAR(50)")]
        public string ACategoryName { get; set; }

        [DataField("INT")]
        public int AR { get; set; }
    }
}
