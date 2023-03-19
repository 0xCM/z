//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record class EcmaProjectFile
    {
        public readonly AssemblyKey Key;

        public readonly AssemblyFile Source;

        public readonly EcmaDependencySet Dependencies;

        public EcmaProjectFile(AssemblyKey key, AssemblyFile src, EcmaDependencySet deps)
        {
            Key = key;
            Source = src;
            Dependencies = deps;
        }

        public string Format()
        {
            var dst = text.emitter();
            dst.AppendLine($"{Key.Name}/{Key.Version}/{Source.Path}");
            iter(Dependencies.ManagedDependencies, v => dst.AppendLine($"  --> managed/{v.TargetName}/v{v.TargetVersion}"));
            iter(Dependencies.NativeDependencies, v => dst.AppendLine($"  --> native/{v.TargetName}"));
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}