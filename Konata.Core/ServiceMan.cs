﻿using System;
using System.Collections.Generic;
using Konata.Events;

namespace Konata
{
    public partial class ServiceMan : EventComponent
    {
        private Dictionary<string, ServiceRoutine> svcRoutines;

        public ServiceMan(EventPumper eventPumper)
            : base(eventPumper)
        {
            svcRoutines = new Dictionary<string, ServiceRoutine>();

            Initialize(eventPumper);
        }

        private void RegisterRoutines(ServiceRoutine routine)
            => svcRoutines.Add(routine.ServiceName, routine);

        protected override EventParacel OnEvent(EventParacel eventParacel)
        {
            return EventParacel.Reject;
        }
    }

    public abstract class ServiceRoutine : EventComponent
    {
        public string ServiceName { get; private set; }

        public ServiceRoutine(string serviceName, EventPumper eventPumper)
            : base(eventPumper)
        {
            ServiceName = serviceName;
        }
    }
}