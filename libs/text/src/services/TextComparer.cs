//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextLengthComparer : IComparer<string>
    {
        [MethodImpl(Inline)]
        public static TextLengthComparer create(bool inverted = false)
            => new TextLengthComparer(inverted);

        readonly bool Inverted;

        [MethodImpl(Inline)]
        public TextLengthComparer(bool inverted)
        {
            Inverted = inverted;
        }

        public int Compare(string x, string y)
        {
            if(x == null || y == null)
                return -1;

            var xL = x.Length;
            var yL = y.Length;
            if(Inverted)
            {
                if(xL == yL)
                    return y.CompareTo(x);
                else
                    return yL.CompareTo(xL);
            }
            else
            {
                if(xL == yL)
                    return x.CompareTo(y);
                else
                    return xL.CompareTo(yL);
            }
        }
    }
}