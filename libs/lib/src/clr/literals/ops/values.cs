//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct ClrLiterals
    {
        /// <summary>
        /// Selects the binary literals declared by a specified type that are of a specified primal type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <typeparam name="T">The primal literal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] values<T>(Base2 @base, Type src)
            where T : unmanaged
                => src.LiteralFields().Where(f => f.FieldType == typeof(T) && f.Tagged<BinaryLiteralAttribute>()).Select(x => (T)x.GetRawConstantValue());

        [MethodImpl(Inline), Op]
        public static void values(in CoveredLiterals src, Span<object> dst)
            => src.WriteValues(dst);

        public static void values<T>(ref T src, Span<Paired<FieldInfo,object>> dst)
            where T : struct
                => values(ref src, typeof(T).DeclaredFields(), dst);

        public static void values<T>(ref T src, ReadOnlySpan<FieldInfo> fields, Span<Paired<FieldInfo,object>> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(src);
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(target,i) = Tuples.paired(field, field.GetValueDirect(tRef));
            }
        }

        /// <summary>
        /// Extracts literal field values of parametrically-identified type that are declared by a specified type
        /// </summary>
        /// <param name="src">The declaring type</param>
        /// <typeparam name="T">The literal type</typeparam>
        [Op, Closures(Closure)]
        public static Pairings<FieldInfo,T> values<T>(Type src)
        {
            var fields = search<T>(src).Index();
            var dst = alloc<Paired<FieldInfo,T>>(fields.Count);
            var tRef = __makeref(src);
            for(var i=0u; i<fields.Count; i++)
            {
                ref readonly var field = ref fields[i];
                seek(dst,i) = Tuples.paired(field, (T)field.GetValueDirect(tRef));
            }
            return dst;
        }
    }
}