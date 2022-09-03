//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Demand
    {
        public static bool @true(bool src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            if(!src)
                Fail.@false(caller,file,line);
            return src;
        }

        public static T nonempty<T>(T src, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : INullity
        {
            if(src.IsEmpty)
                Fail.empty(src, caller,file,line);
            return src;
        }

        public static T eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.eq(a,b,caller,file,line);
            return a;
        }

        public static T eq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.eq(name, a,b,caller,file,line);
            return a;
        }

        public static T lt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result >= 0)
                Fail.nlt(a,b,caller,file,line);
            return a;
        }

        public static T lt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result >= 0)
                Fail.nlt(name,a,b,caller,file,line);
            return a;
        }

        public static T lteq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result > 0)
                Fail.gt(a,b,caller,file,line);
            return a;
        }

        public static T lteq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result > 0)
                Fail.gt(name, a, b, caller,file,line);
            return a;
        }

        public static T gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result <= 0)
                Fail.ngt(a,b,caller,file,line);
            return a;
        }
        public static T gt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result <= 0)
                Fail.ngt(name,a,b,caller,file,line);
            return a;
        }

        public static ReadOnlySpan<T> eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            var count = eq(a.Length,b.Length, caller, file, line);
            for(var i=0; i<count; i++)
            {
                ref readonly var left = ref Spans.skip(a,i);
                ref readonly var right = ref Spans.skip(b,i);
                eq(left,right, caller,file, line);
            }
            return a;
        }
    }
}