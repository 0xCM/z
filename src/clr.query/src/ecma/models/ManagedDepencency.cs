//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ManagedDependency : IComparable<ManagedDependency>
    {
        const string TableName = "ecma.deps.managed";

        [Render(64)]
        public ClrAssemblyName Source;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(64)]
        public ClrAssemblyName TargetName;

        [Render(16)]
        public AssemblyVersion TargetVersion;

        [Render(32)]
        public Hex64 TargetKey;

        public int CompareTo(ManagedDependency src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}