//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public sealed record class ManagedDependency : IComparable<ManagedDependency>
    {
        const string TableName = "ecma.deps.managed";

        [Render(64)]
        public ClrAssemblyName SourceName;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(32)]
        public Hex64 SourceKeyToken;

        [Render(64)]
        public ClrAssemblyName TargetName;

        [Render(16)]
        public AssemblyVersion TargetVersion;

        [Render(32)]
        public Hex64 TargetKeyToken;
        
        public int CompareTo(ManagedDependency src)
        {
            var result = SourceName.CompareTo(src.SourceName);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}