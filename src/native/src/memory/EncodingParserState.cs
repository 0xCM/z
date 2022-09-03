//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the potential byte parser states
    /// </summary>
    public enum EncodingParserState
    {
        None = 0,

        Accepting = 1,

        Failed = 2,

        Succeeded = 4,

        Unmatched = 8,

        Completed = Failed | Succeeded
    }
}