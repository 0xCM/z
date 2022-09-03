//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Require
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static void invariant(bool invariant, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!invariant)
                Throw.sourced("The invariant, it failed", caller, file, line);
        }

        /// <summary>
        /// Insists upon invariant satisfaction
        /// </summary>
        /// <param name="invariant">It must be so, or the operation will not go</param>
        /// <param name="f">A function that emits a message to throw upon invariant failure</param>
        [MethodImpl(Inline), Op]
        public static void invariant(bool invariant, in Func<string> f)
        {
            if(!invariant)
                sys.@throw(f());
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T invariant<T>(bool invariant, T src, in Func<string> f)
        {
            if(!invariant)
                sys.@throw(f());
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nonzero<T>(T src)
            where T : unmanaged
        {
            if(sys.bw64(src) == 0)
                sys.@throw("The source value is zero");
            return src;
        }

        [MethodImpl(Inline)]
        public static T notnull<T>(T src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(src == null)
               Throw.sourced("!!null!!", caller, file, line);
            return src;
        }

        [MethodImpl(Inline), Op]
        public static string nonempty(string src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(sys.empty(src))
               Throw.sourced("Empty string", caller, file, line);
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T predicate<T>(T src, Func<T,bool> f)
        {
            invariant(f(src),  () => $"The centre does not hold");
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] notnull<T>(T[] src)
        {
            if(src is null)
                Throw.message("Null arrays are bad");
            return src;
        }

        [MethodImpl(Inline), Op]
        public static void invariant(bool invariant, string msg, string caller, string file, int? line)
        {
            if(!invariant)
                Throw.sourced(msg, caller, file, line);
        }

        [MethodImpl(Inline), Op]
        public static void require(bool invariant, string msg, in AppMsgSource src)
        {
            if(!invariant)
                Throw.sourced(msg, src);
        }

        [MethodImpl(Inline)]
        public static ulong equal<N>(ulong src, N n = default)
            where N : unmanaged, ITypeNat
        {
            const string Pattern = "The natural value {0} and the operand value {1} are different";

            if(Typed.nat64u<N>() == src)
                return src;
            else
            {
                Throw.message(string.Format(Pattern, n, src));
                return 0;
            }
        }

        [MethodImpl(Inline)]
        public static int equal<N>(int src, N n = default)
            where N : unmanaged, ITypeNat
        {
            const string Pattern = "The natural value {0} and the operand value {1} are different";
            if(Typed.nat32i<N>() == src)
                return src;
            else
            {
                Throw.message(string.Format(Pattern, n, src));
                return 0;
            }
        }

        [MethodImpl(Inline)]
        public static T equal<T>(T a, T b)
            where T : IEquatable<T>
        {
            if(a.Equals(b))
            {
                return a;
            }
            else
            {
                Throw.message(string.Format("{0} != {1}", a, b));
                return default;
            }
        }
    }
}