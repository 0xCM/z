//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Size=Size)]
    public record struct PeSig
    {
        public const byte LocationOffset = 0x3C;

        public const byte Size = 4;

        static ReadOnlySpan<AsciCode> Data => new AsciCode[]{AsciCode.P, AsciCode.E, AsciCode.Null, AsciCode.Null};

        public static PeSig Required 
            => sys.first(sys.recover<AsciCode,PeSig>(Data));
    }
}