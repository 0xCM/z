//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes the outcome of a native capture operation
    /// </summary>
    public readonly struct CaptureOutcome
    {
        [Op, MethodImpl(Inline)]
        public static CaptureOutcome create(ExtractTermCode tc, long start, long end, int delta)
            => new CaptureOutcome(((ulong)start, (ulong)(end + delta)), tc);

        /// <summary>
        /// The origin of the captured data
        /// </summary>
        public readonly MemoryRange Range;

        /// <summary>
        /// The capture termination code indicating why the capture process reached end-state
        /// </summary>
        public readonly ExtractTermCode TermCode;

        [MethodImpl(Inline)]
        public CaptureOutcome(MemoryRange range, ExtractTermCode cc)
        {
            Range = range;
            TermCode = cc;
        }

        public ulong Start
        {
            [MethodImpl(Inline)]
            get => Range.Min;
        }

        public ulong End
        {
            [MethodImpl(Inline)]
            get => Range.Max;
        }

        public int ByteCount
        {
            [MethodImpl(Inline)]
            get => (int)Range.ByteCount;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => End - Start == 0 && TermCode == ExtractTermCode.None;
        }

        public static CaptureOutcome Empty
            => new CaptureOutcome(MemoryRange.Empty, 0);
    }
}