//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AssemblyImporter : Channeled<AssemblyImporter>
    {
        readonly ConcurrentDictionary<AssemblyKey,EcmaDependencySet> Deps = new();
        
        readonly ConcurrentDictionary<AssemblyKey,ReadOnlySeq<EcmaTypeDef>> TypeDefs = new();

        readonly ConcurrentDictionary<AssemblyKey,EcmaProjectFile> ProjectFiles = new();

        IDbArchive Target;

        public AssemblyImporter()
        {
        }
        
        
        public EcmaDependencySet Dependencies(AssemblyKey key)
            => Deps[key];

        public ReadOnlySeq<EcmaTypeDef> Types(AssemblyKey key)
            => TypeDefs[key];

        public void Import(AssemblyIndex src, IDbArchive dst)
        {
            iter(src.Distinct(), entry => Import(entry.File), true);
        }

        public void Import(IEnumerable<AssemblyFile> src, IDbArchive dst)
        {
            Target = dst;
            iter(src, file => Import(file), true);
        }

        ExecToken Import(AssemblyFile src)
        {
            var flow = Channel.Running($"Importing {src.Path}");                
            using var file = Ecma.file(src.Path);
            var reader = Ecma.reader(file);
            var key = reader.AssemblyKey();
            var deps = reader.ReadDependencySet();
            Deps.TryAdd(key, deps);
            TypeDefs.TryAdd(key,reader.ReadTypeDefs());
            ProjectFiles.TryAdd(key, new EcmaProjectFile(key, src, deps));
            return Channel.Ran(flow, $"Imported {src.Path}");            
        }
    }
}