//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ToolCmdArg : IToolCmdArg<string>
    {
        public readonly string Name;

        public readonly string Value;

        public readonly bool IsFlag;

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, string value, bool flag = false)
        {
            Name = name;
            Value = value;
            IsFlag = flag;
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

        string IToolCmdArg<string>.Value 
            => Value;

        string IToolCmdArg.Name  
            => Name;

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