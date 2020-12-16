using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using NewsPublisherWebApp.Models;
using System.Web;
using NewsPublisherWebApp.BusinessLogic;
using System.Configuration;

namespace NewsPublisherWebApp.Utility
{
    public  class Utilities
    {
        public List<SourceDetails> GetAllSources() {

            return LoadSourceMasterList();
          
        }

        public List<SourceDetails> LoadSourceMasterList() {
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SourceMasterListKey"])))
            {
                
                string json = r.ReadToEnd();
                List<SourceDetails> items = JsonConvert.DeserializeObject<List<SourceDetails>>(json);
                return  items.Count > 0 ? items : null;
                
            }

        }

        public string WriteSourceMasterList(SourceBase detailObj)
        {
            var resultSet = LoadSourceMasterList();
            List<SourceBase> modifiedList = new List<SourceBase>();
            foreach (var item in resultSet)
            {
                foreach (var innerItem in item.Sources)
                {
                    if (innerItem.SourceName.Equals(detailObj.SourceName))
                    {
                        //  modifiedList.Add(detailObj);
                        innerItem.SourceName = detailObj.SourceName;
                        innerItem.SourceType = detailObj.SourceType;
                        innerItem.Registered = detailObj.Registered;
                    }
                }
            }

            //open file stream
            using (StreamWriter file = File.CreateText(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SourceMasterListKey"])))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, resultSet);
            }

            return "success";
        }




    }
}