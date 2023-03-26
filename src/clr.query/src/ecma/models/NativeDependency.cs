//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class NativeDependency : IComparable<NativeDependency>
    {
        [Render(64)]
        public ClrAssemblyName Source;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(1)]
        public @string TargetName;

        public int CompareTo(NativeDependency src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}