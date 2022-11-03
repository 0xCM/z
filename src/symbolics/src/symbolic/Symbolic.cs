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

        const NumericKind Closure = UnsignedInts;

        public static ReadOnlySeq<ApiLiteralInfo> apilits(Assembly[] src)
        {
            var providers = src.Types().Tagged<LiteralProviderAttribute>()
                  .Select(x => (Type:x, Attrib:x.Tag<LiteralProviderAttribute>().Require()))
                  .Select(x => new LiteralProvider(x.Type.Assembly.Id(), x.Type, x.Attrib.Group, x.Type.Name)).Index();
            var literals = Literals.runtimelits(providers);
            var count = literals.Count;
            var dst = sys.alloc<ApiLiteralInfo>(count);
            for(var i=0u; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var literal = ref literals[i];
                target.Part = literal.Part;
                target.Type = literal.Type;
                target.Group = literal.Group;
                target.Name = literal.Name;
                target.Kind = literal.Kind.ToString();
                target.Value = literal.Value;
            }
            return dst.Sort();
        }


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
            var store = Symbolic.store<string>(count);
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