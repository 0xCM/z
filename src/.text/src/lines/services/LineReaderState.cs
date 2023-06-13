//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct LineReaderState
    {
        public readonly StreamReader Source;

        public uint LineCount;

        public uint Offset;

        [MethodImpl(Inline)]
        public LineReaderState(StreamReader src)
        {
            Source = src;
            LineCount = 0;
            Offset = 0;
        }
    }
}