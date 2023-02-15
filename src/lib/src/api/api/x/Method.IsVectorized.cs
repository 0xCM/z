//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo m, W128 w)
            => IsVectorized(m) && m.Parameters(p => p.ParameterType.IsVector(w)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo m, W256 w)
            => IsVectorized(m) && m.Parameters(p => p.ParameterType.IsVector(w)).Count() != 0;

        /// <summary>
        /// /// Determines whether a method has intrinsic parameters or return type
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src)
            => src.ReturnType.IsVector() || src.ParameterTypes().Any(VK.test);

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W512 w)
            => vreflect.IsVectorized(src, w);

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W128 w, Type tCell)
            => vreflect.IsVectorized(src, w, tCell);

        /// <summary>
        /// Determines whether a method has at least one 256-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W256 w, Type tCell)
            => vreflect.IsVectorized(src, w, tCell);

        /// <summary>
        /// Determines whether a method has at least one 512-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W512 w, Type tCell)
            => vreflect.IsVectorized(src, w, tCell);

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W128 w, GenericState g = default)
            => IsVectorized(src,w) && src.IsMemberOf(g);

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W256 w, GenericState g = default)
            => IsVectorized(src, w) && src.IsMemberOf(g);

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(this MethodInfo src, W512 w, GenericState g = default)
            => src.IsVectorized(w) && src.IsMemberOf(g);
   }
}