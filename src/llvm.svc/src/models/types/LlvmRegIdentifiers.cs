//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class LlvmRegIdentifiers : ConstLookup<string,LlvmRegIdentifier>
    {
        public LlvmRegIdentifiers(LlvmRegIdentifier[] src)
            : base(src.Map(x => (x.Name.Format(), x)).ToDictionary())
        {

        }

        public static implicit operator LlvmRegIdentifiers(LlvmRegIdentifier[] src)
            => new LlvmRegIdentifiers(src);

        public static new LlvmRegIdentifiers Empty => new(sys.empty<LlvmRegIdentifier>());
    }
}