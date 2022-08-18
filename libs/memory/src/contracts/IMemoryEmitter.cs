//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    [Free]
    public interface IMemoryEmitter
    {
        void Emit(MemoryRange src, StreamWriter dst, byte bpl = 40);

        void Emit(MemoryRange src, FS.FilePath dst, byte bpl = 40);

        void Emit(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = 40);

        void EmitPaged(MemoryRange src, StreamWriter dst, byte bpl = 40);

        void EmitPaged(MemoryRange src, FS.FilePath dst, byte bpl = 40);

        void EmitPaged(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = 40);
    }
}