//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    [ApiHost]
    public static partial class AppErrors
    {
        const string Delimiter = " | ";

        public static AppException missing([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NotImplemented(caller,file,line));

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static string neq<T>(T lhs, T rhs)
             => string.Concat($"The operands are not equal", Delimiter, $"{lhs} != {rhs}");

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static string neq<T>(T lhs, T rhs, string caller, string file, int? line)
             => string.Concat(neq(lhs,rhs), Delimiter, AppMsg.source(caller,file,line));

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static string NotTrue<T>(T src)
            => string.Concat("Predicate evaluation failed", Delimiter, src);

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static string NotTrue<T>(T src, string caller, string file, int? line)
             => string.Concat(NotTrue(src), Delimiter, AppMsg.source(caller,file,line));

        [Op]
        public static AppException Equal(object lhs, object rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.Equal(lhs,rhs,caller,file,line));

        [Op]
        public static AppException NotLessThan(object lhs, object rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NotLessThan(lhs,rhs,caller,file,line));

        [Op]
        public static AppException ItemsNotEqual(int index, object lhs, object rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.ItemsNotEqual(index, lhs,rhs,caller,file,line));

        [Op]
        public static AppException NotNonzero([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NotNonzero(caller,file,line));

        [Op]
        public static AppException NotTrue(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NotTrue(msg, caller, file, line));

        [Op]
        public static AppException NotFalse(string msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NotFalse(msg, caller, file, line));

        [Op]
        public static AppException LengthMismatch(int lhs, int rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.LengthMismatch(lhs, rhs, caller, file, line));

        [Op]
        public static AppException NonGenericMethod(MethodInfo method, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.NonGenericMethod(method,caller,file,line));

        [Op]
        public static AppException GenericMethod(MethodInfo method, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.GenericMethod(method,caller,file,line));

        [Op]
        public static AppException FileDoesNotExist(string path, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.FileDoesNotExist(path, caller, file, line));

        [Op]
        public static ArgumentException BadArg(object arg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ArgumentException((arg?.ToString() ?? string.Empty) + ErrorMsg.FormatCallsite(caller, file,line));

        [Op]
        public static void ThrowBadArg(object arg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw(BadArg(arg,caller,file,line));

        public static Func<string, string, int?, string> NullArgFormatter
            => NullArgMsg.Sourced;

        [MethodImpl(Inline), Op]
        public static string NullArg()
             => NullArgMsg.MsgText;

        [MethodImpl(Inline), Op, Closures(UInt32k)]
        public static string NullArg(string caller, string file, int? line)
             => NullArgMsg.Sourced(caller,file,line);

        [Op, Closures(UInt32k)]
        public static void ThrowNotEqual<T>(T lhs, T rhs, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw new Exception(neq(lhs,rhs,caller,file,line));

        [Op, Closures(UInt32k)]
        public static T ThrowNotEqualNoCaller<T>(T lhs, T rhs)
            => throw new Exception(neq(lhs,rhs));

        [Op]
        public static AppException InvariantFailure(object description, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppException(ErrorMsg.InvariantFailure(description, caller, file, line));

        [Op]
        public static void ThrowInvariantFailure(object description, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw InvariantFailure(description, caller, file, line);

        [Op]
        public static void ThrowIfFalse(bool test, object msg = null, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!test)
                ThrowInvariantFailure(msg, caller, file, line);
        }

        public static void ThrowOutOfRange(int index, int min, int max, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw IndexOutOfRange(index, min, max, caller, file, line);

        [Op]
        public static IndexOutOfRangeException IndexOutOfRange(int index, int min, int max, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new IndexOutOfRangeException(ErrorMsg.IndexOutOfRange(index, min, max, caller, file, line).ToString());

        [Op, Closures(UInt32k)]
        public static IndexOutOfRangeException IndexOutOfRange<T>(T value, T min, T max, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new IndexOutOfRangeException($"Value {value} is not between {min} and {max}: line {line}, member {caller} in file {file}");

        public static IndexOutOfRangeException TooManyBytes(int requested, int available, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new IndexOutOfRangeException(ErrorMsg.TooManyBytes(requested, available, caller, file, line).ToString());

         [Op]
         public static void ThrowTooShort(int dstLen, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw new IndexOutOfRangeException($"The target length {dstLen} is tooShort:{ErrorMsg.FormatCallsite(caller,file,line)}");
    }
}