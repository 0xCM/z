//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ManagedDependency ReadManagedDependency(AssemblyReferenceHandle handle)
        {
            var src = MD.GetAssemblyReference(handle);
            var dst = new ManagedDependency();
            dst.DependencyKind = EcmaDependencyKind.Managed;
            dst.Source = AssemblyName();
            dst.SourceVersion = dst.Source.Version;
            dst.TargetName = src.GetAssemblyName();
            dst.TargetVersion = src.Version;
            dst.TargetKey = u64(Blob(src.PublicKeyOrToken).View);
            dst.TargetHash = Blob(src.HashValue);
            return dst;
        }

        public NativeDependency ReadNativeDependency(ModuleReferenceHandle handle)
        {
            var src = MD.GetModuleReference(handle);
            var dst = new NativeDependency();
            dst.DependencyKind = EcmaDependencyKind.Native;
            dst.Source = AssemblyName();
            dst.SourceVersion = dst.Source.Version;
            dst.TargetName = String(src.Name);
            return dst;
        }

        public ReadOnlySeq<NativeDependency> ReadNativeDeps()
        {
            var native = ModuleRefHandles();
            var count = native.Length;
            var dst = alloc<NativeDependency>(count);
            for(var i=0; i<native.Length; i++)
            {
                seek(dst,i) = ReadNativeDependency(skip(native,i));
            }
            return dst;
        }

        public ReadOnlySeq<ManagedDependency> ReadManagedDeps()
        {
            var managed = AssemblyRefHandles();
            var count = managed.Length;
            var dst = alloc<ManagedDependency>(count);
            var j=0u;
            for(var i=0; i<managed.Length; i++, j++)
            {
                seek(dst,j) = ReadManagedDependency(skip(managed,i));
            }
            return dst;
        }

        public EcmaDependencySet ReadDependencySet()
        {
            var dst = new EcmaDependencySet();
            dst.Source = AssemblyName();
            dst.SourceVersion = dst.Source.Version;
            dst.ManagedDependencies = ReadManagedDeps();
            dst.NativeDependencies = ReadNativeDeps();
            return dst;
        }
    }
}