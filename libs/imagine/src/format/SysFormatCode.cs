//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SysFormatCodes;

    public readonly struct SysFormatCode : ISysFormatCodeHost<SysFormatCode<SysFormatKind,char>,SysFormatKind,char>
    {
        public readonly SysFormatKind Kind {get;}

        public readonly char Code {get;}

        [MethodImpl(Inline)]
        public SysFormatCode(SysFormatKind k, char c)
        {
            Kind = k;
            Code = c;
        }

        [MethodImpl(Inline)]
        public string Apply<T>(T src)
            => api.apply(this, src);

        [MethodImpl(Inline)]
        public static implicit operator SysFormatCode((SysFormatKind kind, char code) src)
            => new SysFormatCode(src.kind, src.code);

        [MethodImpl(Inline)]
        public static implicit operator SysFormatCode(SysFormatCode<char> src)
            => new SysFormatCode(src.Kind, src.Code);
    }
}