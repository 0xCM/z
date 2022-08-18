//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdArg
    {
        public readonly uint Index;

        public readonly string Name;

        public readonly string Value;

        [MethodImpl(Inline)]
        public CmdArg(string name)
        {
            Index = 0;
            Name = name;
            Value = name;
        }

        [MethodImpl(Inline)]
        public CmdArg(string name, string value)
        {
            Index = 0;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, string value)
        {
            Index = index;
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Name);
        }

        public override string ToString()
            => sys.empty(Value) ? Name : string.Format("{0}={1}", Name, Value);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdArg arg)
            => arg.Value;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(string name)
            => new CmdArg(name);

        public static CmdArg Empty
            => new CmdArg(EmptyString);
    }
}