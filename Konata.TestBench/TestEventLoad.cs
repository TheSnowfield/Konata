﻿using Konata.Runtime.Base;
using Konata.Runtime.Base.Event;
using Konata.Runtime.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Konata.Console
{
    [Event(type: "DataComing", runtype: EventRunType.BeforeListener,
        name: "数据到来事件", description: "当数据到来时候触发的事件")]
    public class Test1 : IEvent
    {
        public void Handle(KonataEventArgs arg)
        {
            System.Console.WriteLine("数据到来事件active!");
        }
    }

    [Event(type: "OnDataFixed", runtype: EventRunType.OnlySymbol,
    name: "数据处理完毕时", description: "当数据被处理完毕时的执行内容")]
    public class Test2
    {
    }

    [Component(name: "Socket组件", des: "标准socket组件")]
    public class Test3 :Component,ILoad
    {
        ISocket socket = null;

        public void Load()
        {
            //EventComponent env=Parent.GetComponent<EventComponent>();


        }

        public override void Dispose()
        {

            Recycle = false;
            base.Dispose();
        }
    }

    [Service(name: "协议解析服务", description: "核心协议解析服务")]
    public class PacketService : ILoad,IDisposable
    {
        public void Load()
        {
            
        }
        
        public void CreateNewEntity()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}