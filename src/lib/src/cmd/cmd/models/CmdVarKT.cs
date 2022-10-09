//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdVar<K,T>
        where K : unmanaged
    {
        public readonly @string Name;

        public readonly K Kind;

        public T Value;

        [MethodImpl(Inline)]
        public CmdVar(K id)
        {
            Name = EmptyString;
            Kind = id;
            Value = default;
        }

        [MethodImpl(Inline)]
        public CmdVar(K id, T value)
        {
            Name = EmptyString;
            Kind = id;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar(@string name, K kind, T value)
        {
            Name = name;
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar<K,T> Set(T value)
        {
            Value = value;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>(K name)
            => new CmdVar<K,T>(name);

        [MethodImpl(Inline)]
        public string Format()
            => Value?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>((K id, T value) src)
            => new CmdVar<K,T>(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>(Paired<K,T> src)
            => new CmdVar<K,T>(src.Left, src.Right);
    }
}