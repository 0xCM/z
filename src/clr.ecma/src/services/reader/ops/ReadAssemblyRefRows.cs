//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        public AssemblyRefRow ReadAssemblyRefRow(AssemblyReferenceHandle handle)
        {
            var src = MD.GetAssemblyReference(handle);
            var dst = default(AssemblyRefRow);
            dst.Index = handle;
            dst.Culture = src.Culture;
            dst.Flags = src.Flags;
            dst.Hash = src.HashValue;
            dst.KeyOrToken = src.PublicKeyOrToken;
            dst.Version = src.Version;
            dst.Name = src.Name;
            return dst;
        }

        [Op]
        public ReadOnlySeq<AssemblyRefRow> ReadAssemblyRefRows()
        {
            var src = AssemblyRefHandles();
            var buffer = alloc<AssemblyRefRow>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(buffer,i) = ReadAssemblyRefRow(skip(src,i));            
            return buffer;
        }

        public AssemblyRef ReadAssemblyRef(AssemblyReferenceHandle handle)
        {
            var row = ReadAssemblyRefRow(handle);
            var dst = new AssemblyRef();
            dst.Index = handle;
            dst.Token = BlobArray(row.KeyOrToken);
            dst.Culture = String(row.Culture);
            dst.Flags = row.Flags;
            dst.Hash = BlobArray(row.Hash);
            dst.Name = String(row.Name);
            dst.Version = row.Version;
            return dst;
        }

        public ReadOnlySeq<AssemblyRef> ReadAssemblyRefs()
        {
            var src = AssemblyRefHandles();
            var dst = alloc<AssemblyRef>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = ReadAssemblyRef(skip(src,i));
            return dst;
        }
    }
}