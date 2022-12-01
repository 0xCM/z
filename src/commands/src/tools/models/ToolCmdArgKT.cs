//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    /// <summary>
    /// Defines a kinded argument
    /// </summary>
    public readonly record struct ToolCmdArg<K,T>
        where K : unmanaged
    {
        public readonly K Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public ToolCmdArg(K kind, T value)
        {
            Name = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.Assign, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<K,T>((K kind, T value) src)
            => new ToolCmdArg<K,T>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<K,T>(Paired<K,T> src)
            => new ToolCmdArg<K,T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(ToolCmdArg<K,T> src)
            => new ToolCmdArg(src.Name.ToString(), src.Value?.ToString() ?? EmptyString);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<T>(ToolCmdArg<K,T> src)
            => new ToolCmdArg<T>(src.Name.ToString(), src.Value);
    }
}