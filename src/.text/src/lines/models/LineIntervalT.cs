//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineInterval<T>
    {
        public readonly T Id;

        public readonly LineNumber MinLine;

        public readonly LineNumber MaxLine;

        [MethodImpl(Inline)]
        public LineInterval(T id, LineNumber min, LineNumber max)
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
            => string.Format("{0}:[{1}..{2}]({3})", Id, MinLine, MaxLine, LineCount);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LineInterval<T>((T id, LineNumber min, LineNumber max) src)
            => new LineInterval<T>(src.id,src.min, src.max);

        [MethodImpl(Inline)]
        public static implicit operator LineInterval(LineInterval<T> src)
            => new LineInterval(0, src.MinLine, src.MaxLine);

        public static LineInterval<T> Empty => default;
    }
}