//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public EcmaTables.AssemblyRef ReadAssemblyRefRow(AssemblyReferenceHandle handle)
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
        public ReadOnlySeq<EcmaTables.AssemblyRef> ReadAssemblyRefRows()
        {
            var src = AssemblyRefHandles();
            var buffer = alloc<EcmaTables.AssemblyRef>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                seek(buffer,i) = ReadAssemblyRefRow(skip(src,i));                
            }
            
            return buffer;
        }
    }
}