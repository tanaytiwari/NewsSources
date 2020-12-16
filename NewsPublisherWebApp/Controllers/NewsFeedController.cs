using NewsPublisherWebApp.BusinessLogic;
using NewsPublisherWebApp.Models;
using NewsPublisherWebApp.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace NewsPublisherWebApp.Controllers
{
    public class NewsFeedController : ApiController
    {
        private ISource _source ;
        private Utilities _ut;
        public NewsFeedController() {
            _ut = new Utilities();
        }


        //Get all News Feed Sources
           [HttpGet]
        public IQueryable<SourceDetails> GetNewsFeedSources()
        {
           
            return _ut.GetAllSources().AsQueryable();

        }

        //Method to Register New Feed
        [HttpPost]
        public string RegisterSource([FromBody] SourceBase sb)
        {
            return _ut.WriteSourceMasterList(sb);
        }

        //Method to Get News Feed ACcording to category
        [HttpPost]
        public SourceObject GetNewsBasedOnCategory([FromUri]string categoryName,  [FromBody] SourceBase sourceDetail)
        {
            var result = new SourceObject();
            if (sourceDetail.SourceType == "External") {

                _source = new ExternalSource(sourceDetail);
                result = _source.LoadJson(categoryName);

            }
            else
            {
                _source =  new InternalSource(sourceDetail);
                result = _source.LoadJson(categoryName);
            }
            return result;
        }

        
    }
}
