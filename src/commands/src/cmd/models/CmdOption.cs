//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdOption : ICmdOption
    {
        public readonly @string Name {get;}

        public readonly @string Value {get;}

        [MethodImpl(Inline)]
        public CmdOption(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdOption(string value)
        {
            Name = EmptyString;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Value.IsEmpty ? Name.Format() : string.Format("{0}={1}", Name, Value);

        public override string ToString()
            => Format();

        public static CmdOption Empty
        {
            [MethodImpl(Inline)]
            get => new CmdOption(EmptyString);
        }
    }
}