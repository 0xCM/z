//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [Op]
        public static void @throw(Exception e)
            => sys.@throw(e);

        [Op]
        public static T @throw<T>(Exception e)
            => throw e;

        [Op]
        public static T @throw<T>([CallerName] string caller = null, [CallerLine] int? line = null, [CallerFile] string? path = null)
            => sys.@throw<T>(caller, line, path);

        [MethodImpl(Inline), Op]
        public static void @throw(string msg, [CallerName] string caller = null, [CallerLine] int? line = null, [CallerFile] string? path = null)
            => sys.@throw(msg, caller, line, path);

        [MethodImpl(Inline), Op]
        public static void @throw(Func<string> f)
            => sys.@throw(f);

        [MethodImpl(Inline), Op]
        public static T @throw<T>(object msg)
            => sys.@throw<T>(msg);
    }
}