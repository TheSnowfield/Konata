﻿using System;
using System.Text;

using Konata.Core.Packet;
using Konata.Core.Event;
using Konata.Runtime.Base.Event;

namespace Konata.Core.Service.OidbSvc
{
    [SSOService("OidbSvc.0x8a0_1", "Kick member in the group")]
    class Oidb0x8a0_1 : ISSOService
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
