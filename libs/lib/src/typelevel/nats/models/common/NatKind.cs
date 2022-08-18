//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    /// <summary>
    /// Defines identity for a pair NxT or MxNxT where M and N are natural types and T is numeric
    /// </summary>
    public readonly struct NatKind : IIdentification<NatKind>
    {
        public static NatKind Empty => default;

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public readonly ulong? M;

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public readonly ulong N;

        /// <summary>
        /// The numeric cell type
        /// </summary>
        public readonly NumericKind T;

        static NumericKind ParseNumericKind(string kind)
        {
            var numeric = Numeric.parser<ulong>();
            var indicator = (NumericIndicator)kind.Last();
            var input = kind.TrimEnd(kind.Last());
            if(numeric.Parse(input, out var w))
            {
                return ((NumericWidth)w).ToNumericKind(indicator);
            }
            else
                return 0;
        }

        public static NatKind Parse(string src)
        {
            var numeric = Numeric.parser<ulong>();
            var parts = text.split(src, IDI.SegSep);
            if(parts.Length == 3)
            {
                numeric.Parse(skip(parts,0), out var m);
                numeric.Parse(skip(parts,1), out var n);
                var kind = skip(parts,2);
                if(kind.Length > 0)
                {
                    var nk = ParseNumericKind(kind);
                    return new NatKind(m, n, nk);
                }
            }
            else if(parts.Length == 2)
            {
                numeric.Parse(skip(parts,0), out var n);
                var kind = skip(parts,1);
                if(kind.Length > 0)
                {
                    var nk = ParseNumericKind(kind);
                    return new NatKind(null, n, nk);
                }

            }
            return Empty;
        }

        public Option<Type> MType
            => M.TryMap(m => NativeNaturals.FindType(m)).Value;

        public Type NType
            => NativeNaturals.FindType(N).Require();

        public NumericWidth NumericWidth
            => (NumericWidth)T.Width();

        public string IdentityText
            => M != null
               ? $"{M}{IDI.SegSep}{N}{IDI.SegSep}{T.Format()}"
               : $"{N}{IDI.SegSep}{T.Format()}";

        public static bool operator ==(NatKind d1, NatKind d2)
            => d1.Equals(d2);

        public static bool operator !=(NatKind d1, NatKind d2)
            => !d1.Equals(d2);

        [MethodImpl(Inline)]
        public static implicit operator NatKind((ulong? m, ulong n, NumericKind t) src)
            => new NatKind(src.m,src.n,src.t);

        [MethodImpl(Inline)]
        public static implicit operator (ulong? m, ulong n, NumericKind t)(NatKind src)
            => (src.M, src.N, src.T);

        [MethodImpl(Inline)]
        public NatKind(ulong? m, ulong n, NumericKind t)
        {
            M = m;
            N = n;
            T = t;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => M == 0 && N == 0 && T == 0;
        }

        /// <summary>
        /// Formats the dimension in canonical form
        /// </summary>
        public string Format()
            => IdentityText;

        [MethodImpl(Inline)]
        public bool Equals(NatKind src)
            => M == src.M
            && N == src.N
            && T == src.T;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => HashCode.Combine(M,N);

        public override bool Equals(object src)
            => src is NatKind id && Equals(id);
    }
}