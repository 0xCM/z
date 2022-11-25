//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;
    using System.IO;

    using M = Microsoft.Extensions.DependencyModel;

    public partial class JsonDeps
    {
        [Op]
        public static ProjectDeps load(Assembly src)
            => new ProjectDeps(M.DependencyContext.Load(src));

        public static ProjectDeps parse(Assembly src)
            => parse(src.Path().ChangeExtension(FileKind.JsonDeps));

        [Op]
        public static ProjectDeps parse(FilePath src)
            => new ProjectDeps(context(src.ReadText()));

        internal static M.DependencyContext context(JsonText src)
        {
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            using(var stream = new MemoryStream(Encoding.UTF8.GetMaxByteCount(src.Length)))
            using(var writer = new StreamWriter(stream, encoding))
            {
                writer.Write(src.Content);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using var reader = new M.DependencyContextJsonReader();
                return reader.Read(stream);
            }
        }

        [MethodImpl(Inline), Op]
        public static LibDep lib(string assembly, string version)
        {
            var dst = new LibDep();
            dst.Name= assembly;
            dst.Version = version;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ProjectDependency project(string assembly, string version)
        {
            var dst = new ProjectDependency();
            dst.AssemblyName = assembly;
            dst.AssemblyVersion = version;
            return dst;
        }

        internal static ref RuntimeLib extract(M.RuntimeLibrary src, ref RuntimeLib dst)
        {
            dst.AssemblyGroups = sys.alloc<AssetGroup>(src.RuntimeAssemblyGroups.Count);
            for(var i=0; i<dst.AssemblyGroups.Count; i++)
                extract(src.RuntimeAssemblyGroups[i], ref dst.AssemblyGroups[i]);

            dst.NativeLibraries = sys.alloc<AssetGroup>(src.NativeLibraryGroups.Count);
            for(var i=0; i<dst.NativeLibraries.Count; i++)
                extract(src.NativeLibraryGroups[i], ref dst.NativeLibraries[i]);

            dst.ResourceAssemblies = sys.alloc<ResourceAssembly>(src.ResourceAssemblies.Count);
            for(var i=0; i<dst.ResourceAssemblies.Count; i++)
            {
                ref var target = ref dst.ResourceAssemblies[i];
                target.Path = FS.path(src.ResourceAssemblies[i].Path);
                target.Locale = src.ResourceAssemblies[i].Locale;
            }

            return ref dst;
        }

        internal static ref AssetGroup extract(M.RuntimeAssetGroup src, ref AssetGroup dst)
        {
            dst.Runtime = src.Runtime;
            dst.AssetPaths = src.AssetPaths.Map(FS.path);
            var count = src.RuntimeFiles.Count;
            dst.RuntimeFiles = sys.alloc<RuntimeFileInfo>(count);
            for(var i=0; i<count; i++)
                extract(src.RuntimeFiles[i], ref dst.RuntimeFiles[i]);
            return ref dst;
        }

        internal static ref RuntimeFileInfo extract(M.RuntimeFile src, ref RuntimeFileInfo dst)
        {
            dst.AssemblyVersion = src.AssemblyVersion;
            dst.FileVersion = src.FileVersion;
            dst.Path = FS.path(src.Path);
            return ref dst;
        }

        [Op]
        internal static LibDep[] dependencies(M.CompilationLibrary src)
            => src.Dependencies.Map(d => lib(d.Name, d.Version));

        [Op]
        internal static ref TargetInfo extract(M.DependencyContext context, ref TargetInfo dst)
        {
            var src = context.Target;
            dst.Framework = src.Framework;
            dst.IsPortable = src.IsPortable;
            dst.Runtime = src.Runtime;
            dst.RuntimeSignature = src.RuntimeSignature;
            return ref dst;
        }

        [Op]
        internal static ref Library extract(M.CompilationLibrary src, ref Library dst)
        {
            dst.Name = src.Name;
            dst.Dependencies = dependencies(src);
            dst.Assemblies = src.Assemblies.Array();
            dst.Type = src.Type;
            dst.Path = FS.path(src.Path);
            dst.Version = src.Version;
            dst.Hash = src.Hash;
            dst.Serviceable = src.Serviceable;
            dst.HashPath = src.HashPath;
            dst.RuntimeStoreManifestName = src.RuntimeStoreManifestName;
            dst.ReferencePaths = src.ResolveReferencePaths().Map(FS.path);
            return ref dst;
        }

        [Op]
        internal static ref Options extract(M.CompilationOptions src, ref Options dst)
        {
            dst.AllowUnsafe = src.AllowUnsafe;
            dst.DebugType = src.DebugType;
            dst.Defines = src.Defines.Array();
            dst.DelaySign = src.DelaySign;
            dst.EmitEntryPoint = src.EmitEntryPoint;
            dst.GenerateXmlDocumentation = src.GenerateXmlDocumentation;
            dst.KeyFile = src.KeyFile;
            dst.LanguageVersion = src.LanguageVersion;
            dst.Optimize = src.Optimize;
            dst.Platform = src.Platform;
            dst.PublicSign = src.PublicSign;
            dst.WarningsAsErrors = src.WarningsAsErrors;
            return ref dst;
        }
    }
}