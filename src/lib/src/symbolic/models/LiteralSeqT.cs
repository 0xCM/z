//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class LiteralSeq<T> : Seq<Literal<T>>, ILiteralSeq<T>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly string Name;

        public LiteralSeq(string name, Literal<T>[] values)
            : base(values)
        {
            Name = name;
        }

        Identifier ILiteralSeq<T>.Name
            => Name;
    }
}