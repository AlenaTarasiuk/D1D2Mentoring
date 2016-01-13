using System;
using System.Collections.Generic;
using System.Reflection;

namespace Module7HomeWork
{
    class EventPublisher
    {
        public event EventHandler MyEvent;

        public void CallEvent()
        {
            MyEvent(this, EventArgs.Empty);
        }
    }

    class task2
    {
        void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine(" -> HandleEvent called");
        }

        public static void ToCallMyEvent()
        {
            task2 objTask2 = new task2();
            EventPublisher p = new EventPublisher();
            MethodInfo method = typeof(task2).GetMethod("HandleEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            EventInfo eventInfo = typeof(EventPublisher).GetEvent("MyEvent");
            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, objTask2, method);
            eventInfo.AddEventHandler(p, handler);
            p.CallEvent();
        }
    }
}