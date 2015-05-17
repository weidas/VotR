using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.ConfigurationModel;

namespace VotR.API.ExternalAPIs
{
    public class SystembolagetAPI : IAPI
    {

        public SystembolagetAPI()
        {
            var config = new Configuration();
            var url = config.Get("APISettings:SystembolagetAPI");
        }


    }
}
