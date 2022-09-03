//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct RangeLoop<T> : ITextual
        where T : unmanaged, IComparable<T>
    {
        public T LowerBound;

        public bit LowerInclusive;

        public T UpperBound;

        public bit UpperInclusive;

        public T Step;

        public string Format()
        {
            var dst = text.buffer();
            dst.Append(LowerInclusive ? $"[{LowerBound}" : $"({LowerBound}");
            dst.Append(UpperInclusive ? $", {UpperBound}]" : $", {UpperBound})");
            dst.Append($" step({Step})");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}