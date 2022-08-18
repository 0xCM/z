//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct Pow2Data
    {
        public static ReadOnlySpan<byte> Pow2Bytes => new byte[]
        {
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80,
        };

        public static ReadOnlySpan<byte> M1Bytes32i => new byte[]
        {
            0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00,
            0x0f, 0x00, 0x00, 0x00, 0x1f, 0x00, 0x00, 0x00,
            0x3f, 0x00, 0x00, 0x00, 0x7f, 0x00, 0x00, 0x00,
            0xff, 0x00, 0x00, 0x00, 0xff, 0x01, 0x00, 0x00,
            0xff, 0x03, 0x00, 0x00, 0xff, 0x07, 0x00, 0x00,
            0xff, 0x0f, 0x00, 0x00, 0xff, 0x1f, 0x00, 0x00,
            0xff, 0x3f, 0x00, 0x00, 0xff, 0x7f, 0x00, 0x00,
            0xff, 0xff, 0x00, 0x00, 0xff, 0xff, 0x01, 0x00,
            0xff, 0xff, 0x03, 0x00, 0xff, 0xff, 0x07, 0x00,
            0xff, 0xff, 0x0f, 0x00, 0xff, 0xff, 0x1f, 0x00,
            0xff, 0xff, 0x3f, 0x00, 0xff, 0xff, 0x7f, 0x00,
            0xff, 0xff, 0xff, 0x00, 0xff, 0xff, 0xff, 0x01,
            0xff, 0xff, 0xff, 0x03, 0xff, 0xff, 0xff, 0x07,
            0xff, 0xff, 0xff, 0x0f, 0xff, 0xff, 0xff, 0x1f,
            0xff, 0xff, 0xff, 0x3f, 0xff, 0xff, 0xff, 0x7f,
        };

        public static ReadOnlySpan<byte> M1Bytes32u => new byte[]
        {
            0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00,
            0x0f, 0x00, 0x00, 0x00, 0x1f, 0x00, 0x00, 0x00,
            0x3f, 0x00, 0x00, 0x00, 0x7f, 0x00, 0x00, 0x00,
            0xff, 0x00, 0x00, 0x00, 0xff, 0x01, 0x00, 0x00,
            0xff, 0x03, 0x00, 0x00, 0xff, 0x07, 0x00, 0x00,
            0xff, 0x0f, 0x00, 0x00, 0xff, 0x1f, 0x00, 0x00,
            0xff, 0x3f, 0x00, 0x00, 0xff, 0x7f, 0x00, 0x00,
            0xff, 0xff, 0x00, 0x00, 0xff, 0xff, 0x01, 0x00,
            0xff, 0xff, 0x03, 0x00, 0xff, 0xff, 0x07, 0x00,
            0xff, 0xff, 0x0f, 0x00, 0xff, 0xff, 0x1f, 0x00,
            0xff, 0xff, 0x3f, 0x00, 0xff, 0xff, 0x7f, 0x00,
            0xff, 0xff, 0xff, 0x00, 0xff, 0xff, 0xff, 0x01,
            0xff, 0xff, 0xff, 0x03, 0xff, 0xff, 0xff, 0x07,
            0xff, 0xff, 0xff, 0x0f, 0xff, 0xff, 0xff, 0x1f,
            0xff, 0xff, 0xff, 0x3f, 0xff, 0xff, 0xff, 0x7f,
            0xff, 0xff, 0xff, 0xff,
        };

        public static ReadOnlySpan<byte> M1Bytes64i => new byte[]
        {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x0f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x1f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x0f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x1f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x0f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x1f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x7f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x01, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x03, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x07, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x0f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x1f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x3f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x7f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x01, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x03, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x07, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x0f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x1f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x3f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x7f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x03, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x07, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x0f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x1f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x3f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x07, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x0f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x3f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x07,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x0f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x3f,
        };

        public static ReadOnlySpan<byte> M1Bytes64u => new byte[]
        {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x0f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x1f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x0f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x1f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x0f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x1f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0x7f, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x01, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x03, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x07, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x0f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x1f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x3f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0x7f, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x01, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x03, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x07, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x0f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x1f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x3f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0x7f, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x03, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x07, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x0f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x1f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x3f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x00, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x07, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x0f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x3f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x00,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x07,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x0f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x3f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
        };

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice32iM1(int index)
            => Spans.slice(M1Bytes32i, index*4, 4);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice32uM1(int index)
            => Spans.slice(M1Bytes32u,index*4,4);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice64iM1(int index)
            => M1Bytes64i.Slice(index*8,8);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice64uM1(int index)
            => M1Bytes64u.Slice(index*8,8);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice(int log2IdxFirst, int log2IdxLast)
            => Pow2Bytes.Slice(log2IdxFirst*8, (log2IdxLast - log2IdxFirst)*8);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice32iM1(int i0, int i1)
            => M1Bytes32i.Slice(i0*4, (i1 - i0)*4);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice32uM1(int i0, int i1)
            => M1Bytes32u.Slice(i0*4, (i1 - i0)*4);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice64iM1(int i0, int i1)
            => M1Bytes64i.Slice(i0*8, (i1 - i0)*8);

        [MethodImpl(Inline)]
        static ReadOnlySpan<byte> slice64uM1(int i0, int i1)
            => M1Bytes64u.Slice(i0*8, (i1 - i0)*8);
    }
}