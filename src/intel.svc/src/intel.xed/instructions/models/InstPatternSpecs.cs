//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct PatternSpecs
    {
        public readonly uint PatternId;

        readonly Index<InstPatternSpec> Data;

        [MethodImpl(Inline)]
        public PatternSpecs(uint pattern, InstPatternSpec[] src)
        {
            PatternId = pattern;
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public InstPatternSpec[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref InstPatternSpec this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref InstPatternSpec this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public static implicit operator InstPatternSpec[](PatternSpecs src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<InstPatternSpec>(PatternSpecs src)
            => src.Data;

        public static PatternSpecs Empty => new(0u,sys.empty<InstPatternSpec>());
    }
}
