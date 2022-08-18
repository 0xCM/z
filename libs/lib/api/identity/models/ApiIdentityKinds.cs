//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using NK = NumericKind;
    using ID = ScalarKind;

    [ApiHost]
    public class ApiIdentityKinds
    {
        [Op]
        public static HashSet<NumericKind> distinct(NumericKind k)
        {
            var dst = new HashSet<NumericKind>();
            if(NumericKinds.contains(k, ID.U8))
                dst.Add(NK.U8);

            if(NumericKinds.contains(k, ID.I8))
                dst.Add(NK.I8);

            if(NumericKinds.contains(k, ID.U16))
                dst.Add(NK.U16);

            if(NumericKinds.contains(k, ID.I16))
                dst.Add(NK.I16);

            if(NumericKinds.contains(k, ID.U32))
                dst.Add(NK.U32);

            if(NumericKinds.contains(k, ID.I32))
                dst.Add(NK.I32);

            if(NumericKinds.contains(k, ID.U64))
                dst.Add(NK.U64);

            if(NumericKinds.contains(k, ID.I64))
                dst.Add(NK.I64);

            if(NumericKinds.contains(k, ID.F32))
                dst.Add(NK.F32);

            if(NumericKinds.contains(k, ID.F64))
                dst.Add(NK.F64);

            return dst;
        }

        /// <summary>
        /// Computes the primal types identified by a specified kind
        /// </summary>
        /// <param name="k">The primal kind</param>
        [Op]
        public static HashSet<Type> typeset(NumericKind k)
            => NumericTypeSet(k);

        /// <summary>
        /// Specifies the primal types identified by a <see cref='NumericKind' />
        /// </summary>
        /// <param name="k">The primal kind</param>
        [Op]
        public static HashSet<NumericKind> kindset(NumericKind k)
            => NumericKindSet(k);

        /// <summary>
        /// Produces the formatted identifier of the declaring assembly
        /// </summary>
        /// <param name="host">The source type</param>
        [MethodImpl(Inline)]
        public static string owner(Type host)
            => host.Assembly.Id().Format();

        /// <summary>
        /// Computes a method's numeric closures, predicated on available metadata
        /// </summary>
        /// <param name="m">The source method</param>
        [Op]
        public static NumericKind[] NumericClosureKinds(MethodInfo m)
            => (from tag in m.Tag<ClosuresAttribute>()
                where tag.Kind == TypeClosureKind.Numeric
                let k = (NumericKind)tag.Spec
                select NumericKindSet(k).ToArray()).ValueOrElse(() => sys.empty<NumericKind>());

        [Op]
        public static Type[] NumericClosureTypes(MethodInfo m)
            => from k in NumericClosureKinds(m)
               let t = NumericKinds.type(k)
               where t != typeof(void)
               select t;

        static ConcurrentDictionary<NumericKind, HashSet<NumericKind>> NumericKindSets {get;}
            = new ConcurrentDictionary<NumericKind, HashSet<NumericKind>>();

        static ConcurrentDictionary<NumericKind, HashSet<Type>> NumericTypeSets {get;}
            = new ConcurrentDictionary<NumericKind, HashSet<Type>>();

        [Op]
        static HashSet<Type> CreateTypeset(NumericKind k)
            => distinct(k).Select(NumericKinds.type).ToHashSet();

        [MethodImpl(Inline)]
        static HashSet<NumericKind> NumericKindSet(NumericKind kind)
            => NumericKindSets.GetOrAdd(kind, distinct);

        [MethodImpl(Inline)]
        static HashSet<Type> NumericTypeSet(NumericKind kind)
            => NumericTypeSets.GetOrAdd(kind, CreateTypeset);
    }
}