using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Requests
{
 
     public class GetFirstLimitReachedRequest
    {
       
        [JsonProperty("id")]
        public int Id
        {
            get;
        }

        public GetFirstLimitReachedRequest( int id)
        {
            Id = id;
        }
        
    }
}
