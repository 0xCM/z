//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Pow2x64;

    partial struct Pow2
    {
        /// <summary>
        /// 2^0 = 1
        /// </summary>
        public const byte T00 = 1;

        /// <summary>
        /// 2^1 = 2
        /// </summary>
        public const byte T01 = 2;

        /// <summary>
        /// 2^2 = 4
        /// </summary>
        public const byte T02 = 4;

        /// <summary>
        /// 2^3 = 8
        /// </summary>
        public const byte T03 = 8;

        /// <summary>
        /// 2^4 = 16
        /// </summary>
        public const byte T04 = 16;

        /// <summary>
        /// 2^5 = 32
        /// </summary>
        public const byte T05 = 32;

        /// <summary>
        /// 2^6 = 64
        /// </summary>
        public const byte T06 = 64;

        /// <summary>
        /// 2^7 = 128
        /// </summary>
        public const byte T07 = 128;

        /// <summary>
        /// 2^8 = 256 = UInt8.MaxValue + 1
        /// </summary>
        public const ushort T08 = 256;

        /// <summary>
        /// 2^9 = 512
        /// </summary>
        public const ushort T09 = 512;

        /// <summary>
        /// 2^10 = 1024
        /// </summary>
        public const ushort T10 = 1024;

        /// <summary>
        /// 2^11 = 2048
        /// </summary>
        public const ushort T11 = 2048;

        /// <summary>
        /// 2^12 = 4096
        /// </summary>
        public const ushort T12 = 4096;

        /// <summary>
        /// 2^13 = 8192
        /// </summary>
        public const ushort T13 = 8192;

        /// <summary>
        /// 2^14 = 16,384
        /// </summary>
        public const ushort T14 =  16_384;

        /// <summary>
        /// 2^15 = 32,768
        /// </summary>
        public const ushort T15 = 32_768;

        /// <summary>
        /// 2^16 = 65,536
        /// </summary>
        public const uint T16 = 65_536;

        /// <summary>
        /// 2^17 = 131,072
        /// </summary>
        public const uint T17 = 131_072;

        /// <summary>
        /// 2^18 = 262,144
        /// </summary>
        public const uint T18 = 262_144;

        /// <summary>
        /// 2^19 = 524,288
        /// </summary>
        public const uint T19 = 524_288;

        /// <summary>
        /// 2^20 = 1,048,576
        /// </summary>
        public const uint T20 = 1_048_576;

        /// <summary>
        /// 2^21 = 2,097,152
        /// </summary>
        public const uint T21 = 2_097_152;

        /// <summary>
        /// 2^22 = 4_194_304
        /// </summary>
        public const uint T22 = 4_194_304;

        /// <summary>
        /// 2^23 = 8,388,608
        /// </summary>
        public const uint T23 = 8_388_608;

        /// <summary>
        /// 2^24 = 16,777,216
        /// </summary>
        public const uint T24 = 16_777_216;

        /// <summary>
        /// 2^25 = 33,554,432
        /// </summary>
        public const uint T25 = 33_554_432;

        /// <summary>
        /// 2^26 = 67,108,864 = 0x4000000
        /// </summary>
        public const uint T26 = 0x4000000;

        /// <summary>
        /// 2^27 = 134,217,728 = 0x8000000
        /// </summary>
        public const uint T27 = 0x8000000;

        /// <summary>
        /// 2^28 = 268,435,456 = 0x10000000
        /// </summary>
        public const uint T28 = 0x10000000;

        /// <summary>
        /// 2^29 = 536_870_912 = 0x20000000;
        /// </summary>
        public const uint T29 = 0x20000000;

        /// <summary>
        /// 2^30 = 1,073,741,824 = 0x40000000
        /// </summary>
        public const uint T30 = 0x40000000;

        /// <summary>
        /// 2^31 = 2,147,483,648 = 0x80000000
        /// </summary>
        public const uint T31 = 0x80000000;

        /// <summary>
        /// 2^32 = 4,294,967,296 = 0x100000000
        /// </summary>
        public const ulong T32 = 2*(long)T31;

        public const ulong T33 = 2*T32;

        public const ulong T34 = 2*T33;

        public const ulong T35 = 2*T34;

        public const ulong T36 = (long)K.P2ᐞ36;

        public const ulong T37 = (long)K.P2ᐞ37;

        public const ulong T38 = (long)K.P2ᐞ38;

        public const ulong T39 = (long)K.P2ᐞ39;

        public const ulong T40 = (long)K.P2ᐞ40;

        public const ulong T41 = (long)K.P2ᐞ41;

        public const ulong T42 = (long)K.P2ᐞ42;

        public const ulong T43 = (long)K.P2ᐞ43;

        public const ulong T44 = (long)K.P2ᐞ44;

        public const ulong T45 = (ulong)K.P2ᐞ45;

        public const ulong T46 = (ulong)K.P2ᐞ46;

        public const ulong T47 = (ulong)K.P2ᐞ47;

        public const ulong T48 = (ulong)K.P2ᐞ48;

        public const ulong T49 = (ulong)K.P2ᐞ49;

        public const ulong T50 = (ulong)K.P2ᐞ50;

        public const ulong T51 = (ulong)K.P2ᐞ51;

        public const ulong T52 = (ulong)K.P2ᐞ52;

        public const ulong T53 = (ulong)K.P2ᐞ53;

        public const ulong T54 = (ulong)K.P2ᐞ54;

        public const ulong T55 = (ulong)K.P2ᐞ55;

        public const ulong T56 = (ulong)K.P2ᐞ56;

        public const ulong T57 = (ulong)K.P2ᐞ57;

        public const ulong T58 = (ulong)K.P2ᐞ58;

        public const ulong T59 = (ulong)K.P2ᐞ59;

        public const ulong T60 = (ulong)K.P2ᐞ60;

        public const ulong T61 = (ulong)K.P2ᐞ61;

        public const ulong T62 = (ulong)K.P2ᐞ62;

        /// <summary>
        /// T63 = 9223372036854775808
        /// </summary>
        public const ulong T63 = (ulong)K.P2ᐞ63;

        /// <summary>
        /// 0
        /// </summary>
        public const byte T00m1 = T00 - 1;

        /// <summary>
        /// 1
        /// </summary>
        public const byte T01m1 = T01 - 1;

        /// <summary>
        /// 3
        /// </summary>
        public const byte T02m1 = T02 - 1;

        /// <summary>
        /// 7
        /// </summary>
        public const byte T03m1 = T03 - 1;

        /// <summary>
        /// 15
        /// </summary>
        public const byte T04m1 = T04 - 1;

        /// <summary>
        /// 31
        /// </summary>
        public const byte T05m1 = T05 - 1;

        /// <summary>
        /// 63
        /// </summary>
        public const byte T06m1 = T06 - 1;

        /// <summary>
        /// 127
        /// </summary>
        public const byte T07m1 = T07 - 1;

        /// <summary>
        /// 255
        /// </summary>
        public const byte T08m1 = T08 - 1;

        /// <summary>
        /// 511
        /// </summary>
        public const ushort T09m1 = T09 - 1;

        /// <summary>
        /// 1,023
        /// </summary>
        public const ushort T10m1 = T10 - 1;

        /// <summary>
        /// 2,047
        /// </summary>
        public const ushort T11m1 = T11 - 1;

        /// <summary>
        /// 4,095
        /// </summary>
        public const ushort T12m1 = T12 - 1;

        /// <summary>
        /// 8,193
        /// </summary>
        public const ushort T13m1 = T13 - 1;

        /// <summary>
        /// 16,383
        /// </summary>
        public const ushort T14m1 =  T14 - 1;

        /// <summary>
        /// 32,767
        /// </summary>
        public const ushort T15m1 = T15 - 1;

        /// <summary>
        /// 65,535
        /// </summary>
        public const ushort T16m1 = ushort.MaxValue;

        public const uint T17m1 = T17 - 1;

        public const uint T18m1 = T18 - 1;

        public const uint T19m1 = T19 - 1;

        public const uint T20m1 = T20 - 1;

        public const uint T21m1 = T21 - 1;

        public const uint T22m1 = T22 - 1;

        public const uint T23m1 = T23 - 1;

        public const uint T32m1 = uint.MaxValue;

        public const ulong T64m1 = ulong.MaxValue;
    }
}