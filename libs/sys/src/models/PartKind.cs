//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct PartKind : IExpr, IEquatable<PartKind>, IComparable<PartKind>
    {
        readonly uint Data;

        [MethodImpl(Inline)]
        public PartKind(PartId id)
        {
            Data = (byte)id;
        }

        public PartId ClassId
        {
            [MethodImpl(Inline)]
            get => (PartId)Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public int CompareTo(PartKind src)
            => Format().CompareTo(src.Format());

        public string Format()
            => PartNames.format(ClassId);

        public bool Equals(PartKind src)
            => Data == src.Data;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Data;

        [MethodImpl(Inline)]
        public static implicit operator PartKind(PartId src)
            => new PartKind(src);

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartKind src)
            => src.ClassId;
    }
}