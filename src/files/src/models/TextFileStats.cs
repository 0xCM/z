//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout)]
    public record struct TextFileStats
    {
        public uint MaxLineLength;

        public uint LineCount;

        public uint CharCount;
    }
}