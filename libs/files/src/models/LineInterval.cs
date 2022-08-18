//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineInterval
    {
        public readonly uint Id;

        public readonly LineNumber MinLine;

        public readonly LineNumber MaxLine;

        [MethodImpl(Inline)]
        public LineInterval(uint id, LineNumber min, LineNumber max)
        {
            Id = id;
            MinLine = min;
            MaxLine = max;
        }

        public uint LineCount
        {
            [MethodImpl(Inline)]
            get => MaxLine.Value - MinLine.Value + 1;
        }

        public string Format()
            => string.Format("{0:D5}:[{1}..{2}]({3})", Id, MinLine, MaxLine, LineCount);

        public override string ToString()
            => Format();

        public static LineInterval Empty => default;
    }
}