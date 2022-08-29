//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EventId : IWfEventId<EventId>    
    {
        [MethodImpl(Inline)]
        public static EventId define(string name, WfStepId step)
            => new EventId(name, step, PartToken.Default);

        [MethodImpl(Inline)]
        public static EventId define(Type host, EventKind kind)
            => new EventId(host, kind);

        public string Identifier {get;}

        public Timestamp Ts {get;}

        const string PatternBase = "{0} | {1,-18}";

        EventId(string name, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, name);
        }

        EventId(Type host, EventKind kind)
        {
            Ts = Timestamp.now();
            Identifier = string.Format("{0} | {1,-18} | {2,-16} | {3,-24}", Ts, kind, host.Assembly.Id().Format(), host.DisplayName());
        }

        EventId(string name, WfStepId step, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2,-24}", Ts, name, step);
        }

        /// <summary>
        /// The event data type name
        /// </summary>
        public string Name
            => Identifier;

        [MethodImpl(Inline)]
        public bool Equals(EventId src)
            => Identifier == src.Identifier;

        [MethodImpl(Inline)]
        public int CompareTo(EventId src)
            => Ts.CompareTo(src.Ts);

        public string Format()
            => Identifier.PadRight(56);

        public Hash32 Hashed
        {
            [MethodImpl(Inline)]
            get => sys.hash(Ts.Hash, (uint)(Identifier?.GetHashCode() ?? 0));
        }

        public override int GetHashCode()
            => (int)Hashed;


        public override bool Equals(object src)
            => src is EventId i && Equals(i);

        public override string ToString()
            => Format();

        public static implicit operator EventId(string name)
            => new EventId(name);


        public static EventId Empty
        {
            [MethodImpl(Inline)]
            get => new EventId(EmptyString, Timestamp.Zero);
        }
    }
}