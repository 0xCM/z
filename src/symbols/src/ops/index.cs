//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct Symbols
    {        
        [MethodImpl(Inline)]
        public static Symbols<E> index<E>()
            where E : unmanaged, Enum
                => SymCache<E>.get();

        public static ReadOnlySeq<KeyedValue<E,T>> values<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = index<E>();
            var count = src.Count;
            var dst = sys.alloc<KeyedValue<E,T>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref src[i];
                seek(dst,i) = new KeyedValue<E,T>(s.Kind, sys.@as<ulong,T>(s.Value));
            }
            return dst;
        }

        [Op, Closures(Closure)]
        internal static Sym untyped<T>(Sym<T> src)
            where T : unmanaged
                => new (src.Identity, src.Group, src.Key, src.Type, bw64(src.Kind), src.Name, src.Expr.Text, src.Description, src.Hidden, src.Kind, src.Size);

        public static SymIndex untyped(Type src)
        {
            var factory = typeof(Symbols).Method("index").MakeGenericMethod(src);
            var index = (ISymIndex)factory.Invoke(null, array<object>());
            return index.Untyped();
        }
    }
}