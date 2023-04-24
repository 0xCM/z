//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public AssemblyFileInfo ReadAssemblyFile(AssemblyFileHandle src)
        {
            var file = MD.GetAssemblyFile(src);
            var dst = new AssemblyFileInfo();
            dst.Index = src;
            dst.ContainsMetadata = file.ContainsMetadata;
            dst.Name = new FileUri(String(file.Name));
            dst.Hash = Blob(file.HashValue);
            return dst;
        }

        public ReadOnlySeq<AssemblyFileInfo> ReadAssemblyFiles()
            => AssemblyFileHandles().Map(ReadAssemblyFile);
    }
}