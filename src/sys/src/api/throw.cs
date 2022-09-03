//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static T @throw<T>([CallerName] string caller = null, [CallerLine] int? line = null, [CallerFile] string? path = null)
            => throw new Exception(string.Format("{0}:{1} {2} {3}","!!<bad>!!", caller, line, path));

        [MethodImpl(Options), Op]
        public static void @throw(string msg)
            => throw new Exception(msg);

        [MethodImpl(Options), Op]
        public static void @throw(string msg, string caller, int? line, string path)
            => throw new Exception(string.Format("{0}:{1} {2} {3}",msg, caller, line, path));

        [MethodImpl(Options), Op]
        public static void @throw<E>(E e)
            where E : Exception
                => throw e;

        [MethodImpl(Options), Op]
        public static void @throw(Func<string> f)
            => throw new Exception(f());

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T @throw<T>(Exception e)
            => throw e;

        [MethodImpl(Options), Op]
        public static T @throw<T>(object msg)
            => throw new Exception(msg?.ToString() ?? EmptyString);
    }
}