//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using K = System.IO.WatcherChangeTypes;

[Flags, SymSource("files")]
public enum FileChangeKind : byte
{
    None = 0,

    [Symbol("+")]
    Created = K.Created,

    [Symbol("-")]
    Deleted = K.Deleted,

    [Symbol("M")]
    Modified = K.Changed,

    [Symbol("R")]
    Renamed = K.Renamed,
}    
