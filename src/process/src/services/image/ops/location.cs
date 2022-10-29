//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ImageMemory
    {
        [Op]
        public static ImageLocation location(ProcessModule src)
            =>  new ImageLocation(
                src.Path.FileName.WithoutExtension.Format(),
                (MemoryAddress)src.EntryPointAddress,
                src.BaseAddress,
                src.ModuleMemorySize,
                src.Path
                );
    }
}