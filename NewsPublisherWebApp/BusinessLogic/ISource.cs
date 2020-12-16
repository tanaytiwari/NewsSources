using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPublisherWebApp.Models;

namespace NewsPublisherWebApp.BusinessLogic
{
  public  interface ISource
    {
         SourceObject LoadJson(string catName);
         string SourceType { get; set; }
         string SourceName { get; set; }
         string Registered { get; set; }
     
    }
}
