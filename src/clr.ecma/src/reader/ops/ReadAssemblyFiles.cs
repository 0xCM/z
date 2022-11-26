//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public AssemblyFileInfo ReadAssemblyFile(AssemblyFileHandle src)
        {
            var file = MD.GetAssemblyFile(src);
            var dst = new AssemblyFileInfo();
            dst.ContainsMetadata = file.ContainsMetadata;
            dst.Name = new FileUri(String(file.Name));
            dst.Hash = ReadBlobData(file.HashValue);
            return dst;
        }

        public ReadOnlySeq<AssemblyFileInfo> ReadAssemblyFiles()
            => AssemblyFileHandles().Map(ReadAssemblyFile);
    }
}