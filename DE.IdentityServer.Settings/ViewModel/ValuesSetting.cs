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
        public string startup_routine { get; set; }
        public string forbidden_routine { get; set; }
        public string unauthorized_routine { get; set; }
        public bool log_console_warning_activity { get; set; }
        public bool log_console_debug_activity { get; set; }
        public string max_id_tocken_iat_offset_allowed_in_seconds { get; set; }
        public string apiServer { get; set; }
        public string apiFileServer { get; set; }
    }
}
