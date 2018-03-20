using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE.IdentityServer.Settings.ViewModel
{
    public class ValuesSetting
    {
        public string stsServer { get; set; }
        public string redirect_url { get; set; }
        public string client_id { get; set; }
        public string response_type { get; set; }
        public string scope { get; set; }
        public string post_logout_redirect_uri { get; set; }
        public bool start_checksession { get; set; }
        public bool silent_renew { get; set; }
    }
}
