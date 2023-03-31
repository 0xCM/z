//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct DecodedAsmStatement
    {
        public MemoryAddress IP;

        public BinaryCode Encoded;

        public TextBlock Decoded;

        public static DecodedAsmStatement Empty => default;
    }
}