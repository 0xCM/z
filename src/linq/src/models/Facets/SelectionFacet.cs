//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FacetsDynamic
    {
        public abstract class SelectionFacet
        {
            protected SelectionFacet(string Name)
            {
                this.Name = Name;
            }

            public string Name { get; }

        }

        public abstract class SelectionFacet<F,V> : SelectionFacet
            where F : SelectionFacet<F,V>
        {
            protected SelectionFacet(string Name, V Value)
                : base(Name)
            {
                this.Value = Value;
            }

            public V Value { get; }

            public override string ToString()
                => $"{Name}({Value})";
        }

        public class SelectionFacets
        {
            public static DistinctFacet Distinct()
                =>  new DistinctFacet();

            public static InversionFacet Invert()
                => new InversionFacet();

            public static TopFacet Top(int Count)
                => new TopFacet(Count);
        }
    }
}
