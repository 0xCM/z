//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class EventAttribute : Attribute
    {
        public EventAttribute(EventKind kind)
        {
            EventKind = kind;
            EventName = kind.ToString();
        }

        public EventAttribute(EventKind kind, string name)
        {
            EventKind = kind;
            EventName = name;
        }

        public string EventName {get;}

        public EventKind EventKind {get;}
    }
}