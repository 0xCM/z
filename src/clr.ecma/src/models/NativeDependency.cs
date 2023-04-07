//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public sealed record class NativeDependency : IComparable<NativeDependency>
    {
        const string TableName = "ecma.deps.native";

        [Render(64)]
        public ClrAssemblyName SourceName;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(32)]
        public Hex64 SourceKeyToken;

        [Render(64)]
        public @string TargetName;

        public int CompareTo(NativeDependency src)
        {
            var result = SourceName.CompareTo(src.SourceName);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}