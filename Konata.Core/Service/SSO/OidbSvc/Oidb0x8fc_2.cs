﻿using System;
using System.Text;

using Konata.Core.Packet;
using Konata.Core.Event;
using Konata.Runtime.Base.Event;

namespace Konata.Core.Service.OidbSvc
{
    [SSOService("OidbSvc.0x8fc_2", "Set special title for member")]
    public class Oidb0x8fc_2 : ISSOService
    {
        public bool HandleInComing(EventSsoFrame ssoMessage, out KonataEventArgs output)
        {
            throw new NotImplementedException();
        }

        public bool HandleOutGoing(KonataEventArgs original, out byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}
