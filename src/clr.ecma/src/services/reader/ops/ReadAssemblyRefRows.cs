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
        public ParallelQuery<AssemblyRef> ReadAssemblyRefs()
            =>from handle in AssemblyRefHandles()
                let r = MD.GetAssemblyReference(handle)
                select new AssemblyRef{
                    Index = handle,
                    Token = BlobArray(r.PublicKeyOrToken),
                    Culture = String(r.Culture),
                    Flags = r.Flags,
                    Hash = BlobArray(r.HashValue),
                    Name = String(r.Name),
                    Version = r.Version
                };
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
        public ParallelQuery<AssemblyRefRow> ReadAssemblyRefRows()
            => from handle in AssemblyRefHandles() select ReadAssemblyRefRow(handle);
    }
}