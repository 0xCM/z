//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class Unsupported
    {
        /// <summary>
        /// Populates a <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define<T>([CallerName] string caller = null, [CallerFile]string file = null, [CallerLine] int? line = null)
            => define($"The type {typeof(T).Name}, it is a mystery", caller, file, line);

        /// <summary>
        /// Populates a <see cref="NotSupportedException"/>, populated with a custom message describing why a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define<T>(string description, [CallerName] string caller = null, [CallerFile]string file = null, [CallerLine] int? line = null)
            => define(description, caller, file, line);

        /// <summary>
        /// Populates a <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define(Type t, [CallerName] string caller = null, [CallerFile]string file = null, [CallerLine] int? line = null)
            => define($"The type {t}, it is a mystery", caller, file, line);

        /// <summary>
        /// Defines a <see cref="NotSupportedException"/> with a message complaining that a value is not supported
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        public static NotSupportedException value(object src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => define($"The value {src}, it is bad", caller, file, line);

        /// <summary>
        /// Raises <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static T raise<T>([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw define($"The type {typeof(T).Name} it is a mystery", caller, file, line);

        public static T raise<S,T>([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => throw define($"The transformation {typeof(S).Name} -> {typeof(T).Name} is undefined", caller, file, line);

        [Op]
        public static Exception DuplicateKeyException(IEnumerable<object> keys, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new Exception(string.Concat($"Duplicate keys were detected {string.Join(Chars.Comma, keys)}",  caller,file, line));
        static NotSupportedException define(string msg, string caller, string file, int? line)
            => new NotSupportedException(string.Format("{0}; caller:{1}; line:{2}; file:{3}", msg, caller, line, file));
    }
}