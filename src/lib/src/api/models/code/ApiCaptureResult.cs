//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiCaptureResult
    {
        [MethodImpl(Inline), Op]
        public static ApiCaptureResult create(_OpIdentity id, ExtractTermCode term, MemoryRange range, CodeBlockPair pair)
            => new ApiCaptureResult(term, range, pair);

        /// <summary>
        /// The capture termination code indicating why the capture process reached end-state
        /// </summary>
        public readonly ExtractTermCode TermCode;

        public readonly CodeBlockPair Pair;

        public readonly MemoryRange CaptureRange;

        [MethodImpl(Inline)]
        public ApiCaptureResult(ExtractTermCode term,  MemoryRange range, CodeBlockPair pair)
        {
            TermCode = term;
            Pair = pair;
            CaptureRange = range;
        }
    }
}