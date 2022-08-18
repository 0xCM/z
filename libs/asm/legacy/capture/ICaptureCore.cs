//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines supported x86-encoding capture operations
    /// </summary>
    public interface ICaptureCore
    {
        /// <summary>
        /// Captures jitted x86 encoded assembly for a dynamic delegate
        /// </summary>
        /// <param name="exchange">The selected exchange</param>
        /// <param name="id">The operation identity to confer</param>
        /// <param name="src">The dynamic delegate to capture</param>
        Option<ApiCaptureBlock> Capture(in CaptureExchange exchange, OpIdentity id, in DynamicDelegate src);
    }
}