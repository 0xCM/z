//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdVar<K>
        where K : unmanaged
    {
        public readonly NameOld Name;

        public readonly K Kind;

        public string Value;

        [MethodImpl(Inline)]
        public CmdVar(K id)
        {
            Kind = id;
            Value = EmptyString;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdVar(K kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar(string name, K kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar<K> Set(string value)
        {
            Value = value;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(K name)
            => new CmdVar<K>(name);

        [MethodImpl(Inline)]
        public string Format()
            => Value ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>((K id, string value) src)
            => new CmdVar<K>(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(Paired<K,string> src)
            => new CmdVar<K>(src.Left, src.Right);
    }
}