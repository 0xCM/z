//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [ApiHost]
    public unsafe readonly struct KindConverter
    {
        [Op]
        public static KindConverter create()
        {
            var pIce = gptr(RegConversionData.IceRegisters);
            var pKind = pvoid(RegConversionData.Kinds);
            return new KindConverter(pIce, pKind);
        }

        [MethodImpl(Inline), Op]
        KindConverter(void* pIce, void* pKind)
        {
            IceSource = pIce;
            KindSource = pKind;
        }

        readonly void* IceSource;

        readonly void* KindSource;

        ReadOnlySpan<IceRegister> Ice
        {
            [MethodImpl(Inline)]
            get => @ref<Index<IceRegister>>(IceSource).View;
        }

        ReadOnlySpan<RegKind> Kinds
        {
            [MethodImpl(Inline)]
            get => @ref<Index<RegKind>>(KindSource).View;
        }

        [MethodImpl(Inline), Op]
        public RegKind convert(IceRegister src)
            => skip(Kinds, (int)src);

        [MethodImpl(Inline), Op]
        public IceRegister convert(RegKind src)
            => skip(Ice, (int)src);
    }

    readonly partial struct RegConversionData
    {

    }
}