using NewsPublisherWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace NewsPublisherWebApp.BusinessLogic
{
    public class InternalSource : ISource
    {
        private ISource _source;
        private SourceBase _baseObject;


        public InternalSource(SourceBase baseObject)
        {

            _baseObject = baseObject;
        }

        public string SourceType { get => _source.SourceType; set => _source.SourceType = value; }
        public string SourceName { get => _source.SourceName; set => _source.SourceName = value; }
        public string Registered { get => _source.Registered; set => _source.Registered = value; }

        public SourceObject LoadJson(string catName)
        {

            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["InternalNewsSourceKey"])))
            {
                string json = r.ReadToEnd();
                List<SourceObject> items = JsonConvert.DeserializeObject<List<SourceObject>>(json);
                return items.Where(x => x.SourceName == _baseObject.SourceName && x.SourceType == _baseObject.SourceType && x.Category == catName).FirstOrDefault();
            }
        }
    }
}