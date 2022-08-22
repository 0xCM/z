//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
         public static Span<T> Where<T>(this Span<T> src, Func<T, bool> f)
            => sys.where(src, f);

        public static Span<T> Where<T>(this ReadOnlySpan<T> src, Func<T, bool> f)
            => sys.where(src, f);
   }
}