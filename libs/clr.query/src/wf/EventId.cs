//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        // internal static string DisplayName(this Type src)
        // {
        //     return src.Name;
        // }
    }

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

        [MethodImpl(Inline)]
        EventId(Type type)
        {
            Ts = Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, type.DisplayName());
        }

        [MethodImpl(Inline)]
        EventId(string name, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, name);
        }

        [MethodImpl(Inline)]
        EventId(string name, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase, Ts, name);
        }

        [MethodImpl(Inline)]
        EventId(Type host, EventKind kind)
        {
            Ts = Timestamp.now();
            Identifier = string.Format("{0} | {1,-18} | {2,-16} | {3,-24}", Ts, kind, host.Assembly.Id().Format(), host.DisplayName());
        }

        [MethodImpl(Inline)]
        EventId(string name, WfStepId step, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2,-24}", Ts, name, step);
        }

        [MethodImpl(Inline)]
        EventId(string name, string label, WfStepId step, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, name, label, step);
        }

        [MethodImpl(Inline)]
        EventId(string name, string label, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, name, label);
        }

        [MethodImpl(Inline)]
        EventId(string name, CmdId cmd, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, name, cmd);
        }

        [MethodImpl(Inline)]
        EventId(string name, WfStepId step, EventLevel level, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, name, level, step);
        }

        [MethodImpl(Inline)]
        EventId(EventKind kind, WfStepId step, EventLevel level, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2} | {3}", Ts, kind, level, step);
        }

        [MethodImpl(Inline)]
        EventId(Type type, WfStepId step, PartToken ct, Timestamp? ts = null)
        {
            Ts = ts ?? Timestamp.now();
            Identifier = string.Format(PatternBase + " | {2}", Ts, type.DisplayName(), step);
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

        [MethodImpl(Inline)]
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

        [MethodImpl(Inline)]
        public static implicit operator EventId((Type type, WfStepId step, PartToken ct) src)
            => new EventId(src.type, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, WfStepId step, PartToken ct) src)
            => new EventId(src.name, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, WfStepId step, PartToken ct) src)
            => new EventId(src.kind.ToString(), src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, CmdId cmd, PartToken ct) src)
            => new EventId(src.kind.ToString(), src.cmd, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, WfStepId step, EventLevel level, PartToken ct) src)
            => new EventId(src.name, src.step, src.level, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((EventKind kind, WfStepId step, EventLevel level, PartToken ct) src)
            => new EventId(src.kind, src.step, src.level, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, PartToken ct) src)
            => new EventId(src.name, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId(string name)
            => new EventId(name);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, string label, WfStepId step, PartToken ct) src)
            => new EventId(src.name, src.label, src.step, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, string label, PartToken ct) src)
            => new EventId(src.name, src.label, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId((string name, CmdId cmd, PartToken ct) src)
            => new EventId(src.name, src.cmd, src.ct);

        [MethodImpl(Inline)]
        public static implicit operator EventId(Type row)
            => new EventId(row);

        public static EventId Empty
        {
            [MethodImpl(Inline)]
            get => new EventId(EmptyString, Timestamp.Zero);
        }
    }
}