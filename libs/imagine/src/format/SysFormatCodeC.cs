//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SysFormatCodes;

    public readonly struct SysFormatCode<C> : ISysFormatCodeHost<SysFormatCode<SysFormatKind,C>,SysFormatKind,C>
    {
        public readonly SysFormatKind Kind {get;}

        public readonly C Code {get;}

        [MethodImpl(Inline)]
        public SysFormatCode(SysFormatKind k, C code)
        {
            Kind = k;
            Code = code;
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
        public static implicit operator SysFormatCode<C>((SysFormatKind kind, C code) src)
            => new SysFormatCode<C>(src.kind, src.code);

        [MethodImpl(Inline)]
        public static implicit operator SysFormatCode<C>(SysFormatCode<SysFormatKind,C> src)
            => new SysFormatCode<C>(src.Kind, src.Code);
    }
}