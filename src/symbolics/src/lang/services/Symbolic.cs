//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public partial class Symbolic
    {
        static int SegCount;

        [MethodImpl(Inline)]
        public static ClrEnumAdapter<E> @enum<E>()
            where E : unmanaged, Enum
                => default;

        const NumericKind Closure = UnsignedInts;

        [Op]
        public static uint example(SymStore<string> store, Span<SymRef> refs, Span<string> found)
        {
            var i=0u;
            var j=0u;
            var k=0u;
            store.Deposit("abc", out seek(refs,i++));
            store.Deposit("def", out seek(refs,i++));
            store.Deposit("hij", out seek(refs,i++));
            store.Deposit("klm", out seek(refs,i++));
            store.Deposit("nop", out seek(refs,i++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            return i;
        }

        public static void example()
        {
            var count = 12u;
            var store = Symbols.store<string>(count);
            var refs = sys.alloc<SymRef>(count);
            var found = sys.alloc<string>(count);

            store.Deposit("abc", out var s1);
            store.Deposit("def", out var s2);
            store.Deposit("hij", out var s3);
            store.Deposit("klm", out var s4);
            store.Deposit("nop", out var s5);

            var e1 = store.Find(s1);
            var e2 = store.Find(s2);
            var e3 = store.Find(s3);
            var e4 = store.Find(s4);
            var e5 = store.Find(s5);
        }
    }
}