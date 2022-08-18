//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Correlates a value with a key that uniquely identifies the value within some context
    /// </summary>
    public readonly record struct PartToken : IComparable<PartToken>, IEquatable<PartToken>, IExpr
    {
        [MethodImpl(Inline)]
        public static PartToken create(PartId src)
            => new PartToken(src);

        readonly PartId Value;

        [MethodImpl(Inline)]
        public PartToken(PartId value)
            => Value = value;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(PartToken src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(PartToken other)
            => Value.CompareTo(other.Value);

        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartToken src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator PartToken(PartId src)
            => new PartToken(src);

        public static PartToken Default
            => new PartToken(Assembly.GetEntryAssembly().Id());
    }
}