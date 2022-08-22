//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Seq
    {
        public static Seq<Y> cast<X,Y>(X[] src)
        {
            var dst = sys.alloc<Y>(src.Length);
            for(var i=0; i<src.Length; i++)
                sys.seek(dst,i) = sys.cast<Y>(sys.skip(src,i));
            return dst;
        }

        const NumericKind Closure = UInt64k;

        public static Seq<T> alloc<T>(uint count)
            => sys.alloc<T>(count);

        public static Seq<T> alloc<T>(int count)
            => sys.alloc<T>(count);            
    }
}