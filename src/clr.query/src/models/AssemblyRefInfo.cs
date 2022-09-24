//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a dependency relationship between two assemblies
    /// </summary>
    [StructLayout(StructLayout), Record(TableId)]
    public struct AssemblyRefInfo : IComparable<AssemblyRefInfo>
    {
        const string TableId = "assembly.refs";

        [Render(48)]
        public ClrAssemblyName Source;

        [Render(18)]
        public AssemblyVersion SourceVersion;

        [Render(48)]
        public ClrAssemblyName Target;

        [Render(18)]
        public AssemblyVersion TargetVersion;

        [Render(1)]
        public BinaryCode Token;

        public int CompareTo(AssemblyRefInfo src)
        {
            var left = string.Format("{0}.{1}", Source, Target);
            var right = string.Format("{0}.{1}", src.Source, src.Target);
            return left.CompareTo(right);
        }
    }
}