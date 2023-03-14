//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class NativeDependency : EcmaDependency<NativeDependency>
    {
        public @string TargetName;

        public override int CompareTo(NativeDependency src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = TargetName.CompareTo(src.TargetName);
            return result;
        }
    }
}