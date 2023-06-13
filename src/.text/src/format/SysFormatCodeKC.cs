//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SysFormatCodes;

    public readonly struct SysFormatCode<K,C> : ISysFormatCodeHost<SysFormatCode<K,C>,K,C>
        where K : unmanaged
    {
        public readonly K Kind {get;}

        public readonly C Code {get;}

        [MethodImpl(Inline)]
        public SysFormatCode(K k, C c)
        {
            Kind = k;
            Code = c;
        }

        public string Slot
        {
            [MethodImpl(Inline)]
            get => api.slot(this);
        }

        [MethodImpl(Inline)]
        public string Apply<T>(T src)
            => api.apply(this, src);

        [MethodImpl(Inline)]
        public static implicit operator SysFormatCode<K,C>((K kind, C code) src)
            => new SysFormatCode<K,C>(src.kind, src.code);
    }
}