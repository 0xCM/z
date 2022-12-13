//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ToolCmdArg
    {
        public readonly string Name;

        public readonly string Value;

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Value);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.Assign, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(Pair<string> src)
            => new ToolCmdArg(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg((string name, string value) src)
            => new ToolCmdArg(src.name, src.value);

        public static ToolCmdArg Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdArg(EmptyString, EmptyString);
        }
    }
}