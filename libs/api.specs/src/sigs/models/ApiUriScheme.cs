//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ApiUriScheme : ushort
    {
        None = 0,

        /// <summary>
        /// Marker for operations emitted to a decoded asm file
        /// </summary>
        Asm = 1,

        /// <summary>
        /// Marker for operations emitted to a hex-formatted file
        /// </summary>
        Hex = 2,

        /// <summary>
        /// Marker for stateless hosted operations
        /// </summary>
        Type = 4,

        /// <summary>
        /// Marker for serviced hosted operations
        /// </summary>
        Svc = 8,

        /// <summary>
        /// Marker for memory-located operations
        /// </summary>
        Located = 16,

        /// <summary>
        /// Marker for metadata-located operations
        /// </summary>
        Meta = 32,
    }
}