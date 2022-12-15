//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// The dump type determines the kinds of information that are collected from the process.
    /// </summary>
    public enum DumpTypeOption
    {
        Everything,

        Heap,       // A large and relatively comprehensive dump containing module lists, thread lists, all
                    // stacks, exception information, handle information, and all memory except for mapped images.

        Mini,       // A small dump containing module lists, thread lists, exception information and all stacks.
    }
}