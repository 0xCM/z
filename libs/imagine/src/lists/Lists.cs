//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    using static Spans;

    [ApiHost,Free]
    public class Lists
    {
        const uint DefaultCapacity = 1024;

        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a <see cref='List<T>'/> from a parameter array
        /// </summary>
        /// <param name="src">The source elements</param>
        /// /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static DataList<T> list<T>(params T[] src)
        {
            var length = src?.Length ?? 0;
            if(length == 0)
                return new DataList<T>();
            else
            {
                var dst = new DataList<T>(length);
                dst.AddRange(src);
                return dst;
            }
        }

        [MethodImpl(Inline), Op,Closures(Closure)]
        public uint capacity<T>(DataList<T> src)
            => (uint)storage(src.Storage).Length;

        /// <summary>
        /// Creates a list with specified capacity
        /// </summary>
        /// <param name="capacity">The list capacity</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(AllNumeric)]
        public static DataList<T> list<T>(uint capacity = DefaultCapacity)
            => new DataList<T>((int)capacity);

        /// <summary>
        /// Extracts the underlying buffer (without reallocation)
        /// </summary>
        /// <param name="list">The source list</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op,Closures(Closure)]
        public static T[] storage<T>(List<T> list)
            => ArrayList<T>.Getter(list);

        /// <summary>
        /// Presents the populated cells of the underling buffer
        /// </summary>
        /// <param name="src">The source list</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static ReadOnlySpan<T> view<T>(List<T> src)
            => slice(span(storage(src)),0, src.Count);
    }

    static class ArrayList<T>
    {
        public static Func<List<T>, T[]> Getter;

        /// <summary>
        /// Cribbed this from https://stackoverflow.com/questions/4972951/listt-to-t-without-copying
        /// </summary>
        static ArrayList()
        {
            var attribs = MethodAttributes.Static | MethodAttributes.Public;
            var cc = CallingConventions.Standard;
            var dm = new DynamicMethod("get", attribs, cc, typeof(T[]), new Type[] { typeof(List<T>) }, typeof(ArrayList<T>), true);
            var il = dm.GetILGenerator();

            // Load List<T> argument
            il.Emit(OpCodes.Ldarg_0);
            // Replace argument by field
            il.Emit(OpCodes.Ldfld, typeof(List<T>).GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance));
            // Return field
            il.Emit(OpCodes.Ret);

            Getter = (Func<List<T>, T[]>)dm.CreateDelegate(typeof(Func<List<T>, T[]>));
        }
    }
}