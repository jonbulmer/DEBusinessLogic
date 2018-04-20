using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFileServer.Providers
{
    public class UseOnceAccessIdService
    {
        private double _timeToLive = 30.0;
        private static object lockObject = new Object();

        private List<UseOnceAccessIdService> _useOnceAccessIds = new List<UseOnceAccessId>();  
    }
}
