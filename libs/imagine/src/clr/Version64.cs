//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly record struct Version64 : IDataString<Version64>
    {
        readonly ulong Data;

        [MethodImpl(Inline)]
        public Version64(ulong data)
        {
            Data = data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Data);
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

        public ushort A
        {
            [MethodImpl(Inline)]
            get => (ushort)Data;
        }

        public ushort B
        {
            [MethodImpl(Inline)]
            get => (ushort)(Data >> 16);
        }

        public ushort C
        {
            [MethodImpl(Inline)]
            get => (ushort)(Data >> 32);
        }

        public ushort D
        {
            [MethodImpl(Inline)]
            get => (ushort)(Data >> 48);
        }

        public string Expr
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public string Format()
        {
            var dst = A.ToString();

            if(B != 0)
                dst += ("." + B.ToString());

            if(C != 0)
                dst += ("." + C.ToString());

            if(D != 0)
                dst += ("." + D.ToString());

            return dst;
        }

        public override string ToString()
            => Format();

        public int CompareTo(Version64 src)
            => Expr.CompareTo(src.Expr);
    }
}