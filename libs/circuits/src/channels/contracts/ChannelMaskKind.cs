//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ChannelMaskKind : byte
    {
        None,

        /// <summary>
        /// An application of the mask clears the target
        /// </summary>
        Zero,

        /// <summary>
        /// An application of the mask merges the source with the target
        /// </summary>
        Merge
    }
}