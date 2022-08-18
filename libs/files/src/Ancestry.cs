//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class Ancestry : Lineage<Ancestry,Label>
    {
        public Ancestry(Label name, Label[] ancestors)
            : base(name,ancestors)
        {
        }

        public Ancestry(Label name)
        {
        }

        public Ancestry()
        {
        }
    }
}