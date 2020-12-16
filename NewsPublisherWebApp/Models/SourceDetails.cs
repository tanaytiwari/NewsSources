using NewsPublisherWebApp.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NewsPublisherWebApp.Models
{
    public class SourceDetails: SourceBase
    {
        public List<SourceBase> Sources { get; set; }

    }


}