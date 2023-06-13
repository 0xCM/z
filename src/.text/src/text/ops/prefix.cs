//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op, Closures(Closure)]
        public static string prefix<T>(string p, T src)
            => $"{p}{src}";

        [Op, Closures(Closure)]
        public static string prefix<T>(char p, T src)
            => $"{p}{src}";            
    }
}