//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Errors
    {
        [Op, Closures(UnsignedInts)]
        public static T ThrowOrigin<T>([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => throw originate(caller, file, line);

        [Op]
        static AppException originate([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(AppMsg.error("Mystery Error", caller, file, line));

        [Op]
        public static void Throw(string msg)
            => throw new Exception(msg);

        [Op]
        public static void Throw(string msg, string caller, int? line, string path)
            => throw new Exception(string.Format("{0} | {2}", msg, ErrorMsg.FormatCallsite(caller, path, line)));

        [Op, Closures(UnsignedInts)]
        public static T Throw<T>(object msg)
            => throw new Exception(msg?.ToString() ?? EmptyString);

        [Op]
        public static void Throw(Exception e)
            => throw e;

        [Op]
        public static void Throw(AppException e)
            => throw e;

        [Op, Closures(UnsignedInts)]
        public static T Throw<T>(Exception e)
            => throw e;

        [Op]
        public static void Throw(object e)
            => throw new Exception($"{e}");

        [Op]
        public static void Throw(Func<string> f)
            => throw new Exception(f());

        [Op]
        public static AppException Originate(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => AppException.define(msg, caller, file, line);

        [Op]
        public static void ThrowWithOrigin(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Throw(Originate(msg, caller,file,line));

        [Op]
        public static void ThrowArgNull(object arg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Throw(ArgNull(arg,caller,file,line));

        [Op]
        public static void ThrowBadSize(int expect, int actual, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Throw(new Exception($"The size {actual} is not aligned with {expect}:{ErrorMsg.FormatCallsite(caller,file,line)}"));

        [Op]
        public static void ThrowEmptySpan()
            => Throw($"The span, it is empty");


        [Op]
        static ArgumentNullException ArgNull(object arg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ArgumentNullException((arg?.ToString() ?? string.Empty) + ErrorMsg.FormatCallsite(caller, file,line));
    }
}