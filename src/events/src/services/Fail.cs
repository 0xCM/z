//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct Fail
    {
        public static void @false([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"A value which ought to have been false was true: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void @true([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"A value which ought to have been true was false: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void empty<T>(T src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"Empty value from: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} != {b}: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void eq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} != {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void neq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} == {b}: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void neq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} == {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void nlt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} !< {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void ngt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} !> {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void nlt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} !< {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void ngt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} !> {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} > {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void gt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} > {b}): [{caller}] {FS.path(file).ToUri()}:{line}");
    }
}