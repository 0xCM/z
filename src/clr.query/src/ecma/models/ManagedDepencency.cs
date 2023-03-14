//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ManagedDependency : EcmaDependency<ManagedDependency>, IComparable<ManagedDependency>
    {
        [Render(64)]
        public ClrAssemblyName TargetName;

        [Render(16)]
        public AssemblyVersion TargetVersion;

        [Render(32)]
        public Hex64 TargetKey;

        [Render(32)]
        public BinaryCode TargetHash;

        public override int CompareTo(ManagedDependency src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}