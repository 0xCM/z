//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the available stream-writer modes
    /// </summary>
    [SymSource(files)]
    public enum FileWriteMode
    {
        Overwrite = 0,

        Append = 1
    }
}