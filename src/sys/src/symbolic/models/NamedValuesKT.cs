//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NamedValues<K,T> : ReadOnlySeq<NamedValues<K,T>,NamedValue<K,T>>
        where K : unmanaged, IAsciSeq<K>
    {
        public NamedValues()
        {

        }


        [MethodImpl(Inline)]
        public NamedValues(NamedValue<K,T>[] src)
            : base(src)
        {
        }


        [MethodImpl(Inline)]
        public static implicit operator NamedValues<K,T>(NamedValue<K,T>[] src)
            => new NamedValues<K,T>(src);
    }
}