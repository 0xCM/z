//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EntityLineage
    {
        [Render(64)]
        public readonly string EntityName;

        [Render(1)]
        public readonly Lineage Ancestors;

        [MethodImpl(Inline)]
        public EntityLineage(string name, Lineage ancestors)
        {
            EntityName = name;
            Ancestors = ancestors;
        }

        public string Format()
            => Ancestors.IsEmpty ? EntityName : string.Format("{0} -> {1}", EntityName, Ancestors.Format());

        public override string ToString()
            => Format();
    }
}