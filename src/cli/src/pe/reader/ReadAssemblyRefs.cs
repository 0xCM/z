//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PeReader
    {
        [Op]
        public ReadOnlySeq<AssemblyRefInfo> ReadAssemblyRefs()
        {
            var src = CliReader().AssemblyRefHandles();
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
            dst.Source = AssemblyName();
            dst.SourceVersion = dst.Source.Version;
            dst.Target = src.GetAssemblyName();
            dst.TargetVersion = dst.Target.Version;
            dst.Token = CliReader().Read(src.PublicKeyOrToken);
            return ref dst;
        }
    }
}