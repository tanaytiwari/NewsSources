using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace NewsPublisherWebApp.Models
{
    public class SourceObject 
    {
        public  string SourceType { get; set; }
        public  string SourceName { get; set; }
        public string PubDate { get; set; }
        public string Category { get; set; }
        public List<NewsItem> NewsItem { get; set; }

    }


}