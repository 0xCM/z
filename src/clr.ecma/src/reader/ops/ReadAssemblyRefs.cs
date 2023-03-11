//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public EcmaTables.AssemblyRef ReadAssemblyRef(AssemblyReferenceHandle handle)
        {
            var src = MD.GetAssemblyReference(handle);
            var dst = default(EcmaTables.AssemblyRef);
            dst.Culture = src.Culture;
            dst.Flags = src.Flags;
            dst.Hash = src.HashValue;
            dst.Token = src.PublicKeyOrToken;
            dst.Version = src.Version;
            dst.Name = src.Name;
            return dst;
        }


        [Op]
        public ReadOnlySeq<AssemblyRefInfo> ReadAssemblyRefs()
        {
            var src = AssemblyRefHandles();
            var dst = alloc<AssemblyRefInfo>(src.Length);
            ReadAssemblyRefs(src, dst);
            return dst;
        }

        [Op]
        public void ReadAssemblyRefs(ReadOnlySpan<AssemblyReferenceHandle> src, Span<AssemblyRefInfo> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadAssemblyRef(MD.GetAssemblyReference(skip(src,i)), ref seek(dst,i));
        }

        [Op]
        public ref AssemblyRefInfo ReadAssemblyRef(AssemblyReference src, ref AssemblyRefInfo dst)
        {
            dst.Source = MD.GetAssemblyDefinition().GetAssemblyName();
            dst.Target = src.GetAssemblyName();
            dst.Token = Blob(src.PublicKeyOrToken);
            return ref dst;
        }
    }
}