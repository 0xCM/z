//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class SourceCode<C> : SourceCode<SourceCode<C>, C>
        where C : IEquatable<C>, IComparable<C>, new()
    {
        public SourceCode()
            : base(new C())
        {
            Hash = 0;
        }        

        public SourceCode(C content, Hash32 hash)
            : base(content)
        {
            Hash = hash;
        }

        public override bool IsEmpty => false;

        public override Hash32 Hash {get;}

        public override string Format()
        {
            throw new NotImplementedException();
        }
    }
}