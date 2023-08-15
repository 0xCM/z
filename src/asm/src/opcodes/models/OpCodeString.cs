//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class AsmOpCodes
{
    public readonly struct OpCodeString : IComparable<OpCodeString>
    {
        readonly TextBlock _Data;

        [MethodImpl(Inline)]
        public OpCodeString(string src)
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
            => src is OpCodeString x && Equals(x);

        [MethodImpl(Inline)]
        public bool Equals(OpCodeString src)
            => _Data.Equals(src._Data);

        public int CompareTo(OpCodeString src)
            => _Data.CompareTo(src._Data);

        [MethodImpl(Inline)]
        public static bool operator ==(OpCodeString a, OpCodeString b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(OpCodeString a, OpCodeString b)
            => !a.Equals(b);

        public static OpCodeString Empty
            => new (EmptyString);
    }
}