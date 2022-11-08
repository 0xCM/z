//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly ref struct CaptureExchange
    {
        /// <summary>
        /// The buffer that receives the captured data
        /// </summary>
        internal readonly Span<byte> Buffer;

        [MethodImpl(Inline)]
        public CaptureExchange(Span<byte> capture)
            => Buffer = capture;
    }
}