//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct PartName : IComparable<PartName>, IEquatable<PartName>, IExpr
    {
        public readonly PartId PartId;

        public readonly string PartExpr;

        [MethodImpl(Inline)]
        public PartName()
        {
            PartId = 0;
            PartExpr = EmptyString;
        }

        [MethodImpl(Inline)]
        public PartName(string expr)
        {
            PartExpr = expr;
            PartId = 0;
        }

        public PartName(PartId id)
        {
            PartId = id;
            PartExpr = id.Format();
        }

        [MethodImpl(Inline)]
        public PartName(PartId id, string name)
        {
            PartId = id;
            PartExpr = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(PartExpr);
        }
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(PartExpr);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(PartExpr);
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(PartName src)
            => PartExpr == src.PartExpr;

        public int CompareTo(PartName src)
            => PartExpr.CompareTo(src.PartExpr);

        [MethodImpl(Inline)]
        public string Format()
            => PartExpr ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PartName(string name)
            => new PartName(name);

        [MethodImpl(Inline)]
        public static implicit operator PartName(PartId id)
            => new PartName(id);

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartName name)
            => name.PartId;

        public static PartName Empty => new PartName();
    }
}