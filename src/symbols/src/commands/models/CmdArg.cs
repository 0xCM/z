//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    using static sys;
    
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct CmdArg
    {
        public readonly @string Name;

        public readonly @string Value;

        [MethodImpl(Inline)]
        public CmdArg(string value)
        {
            Name = EmptyString;
            Value = value;
            
        }

        [MethodImpl(Inline)]
        public CmdArg(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsNamed
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | Value.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator string(CmdArg arg)
            => arg.Value;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(string value)
            => new CmdArg(value);

        public static CmdArg Empty
            => new CmdArg(EmptyString);
    }
}