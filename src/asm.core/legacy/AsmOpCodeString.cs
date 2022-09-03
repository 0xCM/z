//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmOpCodeString : IComparable<AsmOpCodeString>
    {
        readonly TextBlock _Data;

        [MethodImpl(Inline)]
        public AsmOpCodeString(string src)
            => _Data = src;

        public TextBlock Content
        {
            [MethodImpl(Inline)]
            get => _Data.Text;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => _Data.Text;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => _Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Data.IsNonEmpty;
        }

        public bool IsValid
        {
            [MethodImpl(Inline)]
            get => text.neq(_Data,"<invalid>", NoCase);
        }

        public override int GetHashCode()
            => _Data.GetHashCode();

        [MethodImpl(Inline)]
        public string Format()
            => _Data.Format();

        public override string ToString()
            => Format();

        public override bool Equals(object src)
            => src is AsmOpCodeString x && Equals(x);

        [MethodImpl(Inline)]
        public bool Equals(AsmOpCodeString src)
            => _Data.Equals(src._Data);

        public int CompareTo(AsmOpCodeString src)
            => _Data.CompareTo(src._Data);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmOpCodeString a, AsmOpCodeString b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmOpCodeString a, AsmOpCodeString b)
            => !a.Equals(b);

        public static AsmOpCodeString Empty
            => new AsmOpCodeString(EmptyString);
    }
}