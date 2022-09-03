
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct CalcChecks
    {
        public static string apply<K,T>(K k, T x, T y)
            where K : IApiClass
                => $"{k.Format()}({x},{y})";

        public static string success<K,T>(K k, T x, T y, T result)
            where K : IApiClass
                => $"{k.Format()}({x},{y}) := {result}";

        public static string failure<K,T>(K k, T x, T y, T expect, T actual)
            where K : IApiClass
                => $"{apply(k,x,y)} := {actual} != {expect}";

        public static string describe<K,T>(K k, T x, T y, T result)
            where K : IApiClass
            where T : IEquatable<T>
                => $"{apply(k,x,y)} = {result}";

        public static string describe<K,T>(K k, T x, T y, T expect, T actual)
            where K : IApiClass
            where T : IEquatable<T>
                => expect.Equals(actual) ? success(k, x, y, actual) : failure(k, x, y, expect, actual);
    }
}