//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMappedFiles : IDisposable
    {
        ref readonly MemoryFile this[ushort index] {get;}

        ref readonly MemoryFile this[MemoryAddress @base] {get;}

        uint FileCount {get;}

        Index<MemoryFileInfo> Descriptions {get;}
    }
}