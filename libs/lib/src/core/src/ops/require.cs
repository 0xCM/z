//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [Op]
        public static void require(bool invariant, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!invariant)
                sys.@throw("The invariant, it failed", caller, line, file);
        }

        /// <summary>
        /// Insists upon invariant satisfaction
        /// </summary>
        /// <param name="invariant">It must be so, or the operation will not go</param>
        /// <param name="f">A function that emits a message to throw upon invariant failure</param>
        [MethodImpl(Inline), Op]
        public static void require(bool invariant, in Func<string> f)
        {
            if(!invariant)
                sys.@throw(f);
        }

        [MethodImpl(Inline), Op]
        public static T require<T>(T src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(src == null)
                sys.@throw($"{caller} supplied a NULL value: {file}:line {line}");
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T require<T>(bool invariant, T src, in Func<string> f)
        {
            if(!invariant)
                sys.@throw(f);

            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T require<T>(T src, Func<T,bool> f)
        {
            require(f(src),  () => $"The centre does not hold");
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] require<T>(T[] src)
        {
            if(src is null)
                sys.@throw("Null arrays are bad");
            return src;
        }

        [MethodImpl(Inline), Op]
        public static void require(bool invariant, string msg, string caller, string file, int? line)
        {
            if(!invariant)
                sys.@throw($"{msg}: Line {line} in {file}");
        }

        [MethodImpl(Inline), Op]
        public static void require(bool invariant, string msg, in AppMsgSource source)
        {
            if(!invariant)
                sys.@throw($"{msg}: {source.Format()}");
        }

        [MethodImpl(Inline)]
        public static ulong insist<N>(ulong src, N n = default)
            where N : unmanaged, ITypeNat
        {
            const string Pattern = "The natural value {0} and the operand value {1} are different";

            if(nat64u<N>() == src)
                return src;
            else
            {
                sys.@throw(string.Format(Pattern, n, src));
                return 0;
            }
        }

        [MethodImpl(Inline)]
        public static int require<N>(int src, N n = default)
            where N : unmanaged, ITypeNat
        {
            const string Pattern = "The natural value {0} and the operand value {1} are different";

            if(nat32i<N>() == src)
                return src;
            else
            {
                sys.@throw(string.Format(Pattern, n, src));
                return 0;
            }
        }
    }
}