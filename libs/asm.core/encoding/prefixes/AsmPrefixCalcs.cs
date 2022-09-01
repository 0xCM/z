//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    using C = AsmPrefixCode;
    using K = AsmPrefixKind;
    using L = AsmPrefixClass;

    public readonly struct AsmPrefixCalcs
    {
        public static AsmPrefixKind kinds(ReadOnlySpan<byte> src)
        {
            var count = src.Length;
            var result = AsmPrefixKind.None;
            for(var i=0; i<count; i++)
            {
                var c = code(skip(src,i));
                if(c != 0)
                    result |= kind(c);
            }
            return result;
        }

        public static AsmPrefixClass @class(AsmPrefixCode src)
            => src switch
            {
                C.SsSegOverride => L.Legacy,
                C.EsSegOverride => L.Legacy,
                C.FsSegOverride => L.Legacy,
                C.GsSegOverride => L.Legacy,
                C.OSZ => L.Legacy,
                C.ASZ => L.Legacy,
                C.BranchTaken => L.Legacy,

                C.BranchNotTaken => L.Legacy,

                C.Lock => L.Legacy,

                C.RepF2 => L.Legacy,

                C.RepF3 => L.Legacy,

                C.Rex => L.REX,

                C.VexC4 => L.VEX,

                C.VexC5 => L.VEX,
                _ => L.None,
            };

        public static AsmPrefixClass @class(AsmPrefixKind src)
            => src switch
            {
                K.SsSegOverride => L.Legacy,

                K.EsSegOverride => L.Legacy,

                K.FsSegOverride => L.Legacy,

                K.GsSegOverride => L.Legacy,

                K.OSZ => L.Legacy,

                K.ASZ => L.Legacy,

                K.BranchTaken => L.Legacy,

                K.BranchNotTaken => L.Legacy,

                K.Lock => L.Legacy,

                K.RepF2 => L.Legacy,

                K.RepF3 => L.Legacy,

                K.Rex => L.REX,

                K.VexC4 => L.VEX,

                K.VexC5 => L.VEX,
                _ => L.None,
            };

        public static AsmPrefixKind kind(AsmPrefixCode code)
            => code switch
            {
                C.CsSegOverride => K.CsSegOverride,

                C.SsSegOverride => K.SsSegOverride,

                C.EsSegOverride => K.EsSegOverride,

                C.FsSegOverride => K.FsSegOverride,

                C.GsSegOverride => K.GsSegOverride,

                C.DsSegOverride => K.DsSegOverride,

                C.Rex => K.Rex,

                C.OSZ => K.OSZ,

                C.ASZ => K.ASZ,

                C.Lock => K.Lock,

                C.RepF2 => K.RepF2,

                C.RepF3 => K.RepF3,

                C.VexC4 => K.VexC4,

                C.VexC5 => K.VexC5,

                _ => K.None,
            };

        public static AsmPrefixCode code(byte src)
            => src switch
            {
                0x0F => C.Escape,

                0x36 => C.SsSegOverride,

                0x26 => C.EsSegOverride,

                0x64 => C.FsSegOverride,

                0x65 => C.GsSegOverride,

                0x40 => C.Rex,

                0x66 => C.OSZ,

                0x67 => C.ASZ,

                0xF0 => C.Lock,

                0xF2 => C.RepF2,

                0xF3 => C.RepF3,

                0xC4 => C.VexC4,

                0xC5 => C.VexC5,

                _ => C.None,
            };
    }
}