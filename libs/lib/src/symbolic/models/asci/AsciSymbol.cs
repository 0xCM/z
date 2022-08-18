//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N1;
    using C = AsciSymbol;

    /// <summary>
    /// Lifts an asci code to a structural type
    /// </summary>
    [ApiHost, DataWidth(7)]
    public readonly struct AsciSymbol : IAsciSeq<C,N>
    {
        public readonly AsciCode Code;

        /// <summary>
        /// Returns a string of length 1 that corresponds to the specified asci code
        /// </summary>
        /// <param name="code">The asci code</param>
        [MethodImpl(Inline), Op]
        static string @string(AsciCode code)
            => new string((char)code,1);

        [MethodImpl(Inline), Op]
        public AsciSymbol(AsciCode code)
            => Code = code;

        public TextBlock Text
        {
            [MethodImpl(Inline), Op]
            get => @string(Code);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Code != 0;
        }

        public bool IsBlank
        {
            [MethodImpl(Inline), Op]
            get => SQ.whitespace(Code);
        }

        public bool IsNull
        {
            [MethodImpl(Inline), Op]
            get => SQ.@null(Code);
        }

        public bool IsNonNull
        {
            [MethodImpl(Inline), Op]
            get => !IsNull;
        }

        [MethodImpl(Inline)]
        public bool Equals(C src)
            => Code == src.Code;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public Hash32 Hash
        {
            [MethodImpl(Inline), Op]
            get => (byte)Code;
        }

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is C c && Equals(c);

        public override string ToString()
            => Text;

        ReadOnlySpan<byte> IByteSeq.View
            => core.bytes(this);

        bool INullity.IsEmpty
            => IsEmpty;

        bool INullity.IsNonEmpty
            => IsNonEmpty;

        int IByteSeq.Length
            => 1;

        bool IEquatable<C>.Equals(C src)
            => Code == src.Code;

        C INullary<C>.Zero
            => Empty;

        string IExpr.Format()
            => Text;

        [MethodImpl(Inline)]
        public int CompareTo(C src)
            => Code.CompareTo(src.Code);

        public static C Empty
            => new C(AsciCode.Null);

        [MethodImpl(Inline)]
        public static implicit operator C(AsciCode src)
            => new AsciSymbol(src);

        [MethodImpl(Inline)]
        public static implicit operator AsciCode(C src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator C(char src)
            => new AsciSymbol((AsciCode)src);

        [MethodImpl(Inline)]
        public static implicit operator char(C src)
            => (char)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator C(AsciCharSym src)
            => new AsciSymbol((AsciCode)src);

        [MethodImpl(Inline)]
        public static implicit operator AsciCharSym(C src)
            => (AsciCharSym)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator C(byte src)
            => new AsciSymbol((AsciCode)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(C src)
            => (byte)src.Code;

        [MethodImpl(Inline)]
        public static explicit operator uint(C src)
            => (uint)src.Code;

        [MethodImpl(Inline)]
        public static explicit operator ushort(C src)
            => (ushort)src.Code;

        [MethodImpl(Inline)]
        public static explicit operator ulong(C src)
            => (ulong)src.Code;

        [MethodImpl(Inline)]
        public static bool operator ==(C a, C b)
            => a.Code == b.Code;

        [MethodImpl(Inline)]
        public static bool operator !=(C a, C b)
            => a.Code != b.Code;

        [MethodImpl(Inline)]
        public static bool operator <(C a, C b)
            => a.Code < b.Code;

        [MethodImpl(Inline)]
        public static bool operator >(C a, C b)
            => a.Code > b.Code;

        [MethodImpl(Inline)]
        public static bool operator <=(C a, C b)
            => a.Code <= b.Code;

        [MethodImpl(Inline)]
        public static bool operator >=(C a, C b)
            => a.Code >= b.Code;

        [MethodImpl(Inline)]
        public static C operator ++(C a)
        {
            var next = (byte)a + 1;
            return new C((AsciCode)next);
        }

        [MethodImpl(Inline)]
        public static C operator --(C a)
        {
            var prior = (byte)a - 1;
            return new C((AsciCode)prior);
        }
    }
}