//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class RP
    {
        [MethodImpl(Inline)]
        static string msgarg<T>(T src)
            => string.Format("<{0}>", src);

        public static string msg<T>(string pattern, T a)
            => string.Format(pattern, msgarg(a));
    }
}