//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(Width)]
    public readonly record struct InstOpSymbol : IComparable<InstOpSymbol>
    {
        public const byte Width = num8.Width;

        readonly asci8 Data;

        [MethodImpl(Inline)]
        internal InstOpSymbol(string src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Data.Format();

        public int CompareTo(InstOpSymbol src)
            => Data.CompareTo(src.Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(InstOpSymbol src)
            => Data == src.Data;

        public override int GetHashCode()
            => Data.GetHashCode();

        public static InstOpSymbol Empty => new InstOpSymbol(EmptyString);
    }
}
