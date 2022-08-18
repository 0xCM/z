//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [MethodImpl(NotInline), Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W128 w, bool generic = false)
            => generic ? src.VectorizedGeneric(w) : src.VectorizedDirect(w);

        /// <summary>
        /// selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W256 w, bool generic = false)
            => generic ? src.VectorizedGeneric(w) : src.VectorizedDirect(w);

        /// <summary>
        /// selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W512 w, bool generic = false)
            => generic ? src.VectorizedGeneric(w) : src.VectorizedDirect(w);

        /// <summary>
        /// Selects vectorized methods from a stream predicated on width, name and generic partition membership
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="name">The name to match</param>
        /// <param name="g">The generic partition to which the considered members belong</param>
        [Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W128 w, string name, bool generic = false)
            => src.Vectorized(w,generic).WithName(name);

        /// <summary>
        /// Selects vectorized methods from a stream predicated on width, name and generic partition membership
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="name">The name to match</param>
        /// <param name="g">The generic partition to which the considered members belong</param>
        [Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W256 w, string name, bool generic = false)
            => src.Vectorized(w,generic).WithName(name);

        /// <summary>
        /// Selects vectorized methods from a stream predicated on width, name and generic partition membership
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="name">The name to match</param>
        /// <param name="generic">The generic partition to which the considered members belong</param>
        [Op]
        public static MethodInfo[] Vectorized(this MethodInfo[] src, W512 w, string name, bool generic = false)
            => src.Vectorized(w,generic).WithName(name);
    }
}