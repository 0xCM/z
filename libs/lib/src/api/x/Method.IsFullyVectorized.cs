//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;

    partial class XApi
    {
        /// <summary>
        /// Determines whether a method has intrinsic parameters or return type
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src)
            => VK.test(src.ReturnType) && src.ParameterTypes().All(VK.test);

        /// <summary>
        /// Determines whether all parameters of a method are 128-bit intrinsic vectors
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W128 w)
            => src.IsFullyVectorized() && src.EffectiveParameterTypes().All(t => t.IsVector(w));

        /// <summary>
        /// Determines whether all parameters of a method are 256-bit intrinsic vectors
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W256 w)
            => src.IsFullyVectorized() && src.EffectiveParameterTypes().All(t => t.IsVector(w));

        /// <summary>
        /// Determines whether all parameters of a method are 256-bit intrinsic vectors
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W512 w)
            => src.IsFullyVectorized() && src.EffectiveParameterTypes().All(t => t.IsVector(w));

        /// <summary>
        /// Determines whether all parameters of a method are 128-bit intrinsic vectors with a specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W128 w, Type tCell)
            => src.IsFullyVectorized(w) && src.ReturnType.IsVector(w,tCell);

        /// <summary>
        /// Determines whether all parameters of a method are 256-bit intrinsic vectors with a specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W256 w, Type tCell)
            => src.IsFullyVectorized(w) && src.ReturnType.IsVector(w,tCell);

        /// <summary>
        /// Determines whether all parameters of a method are 512-bit intrinsic vectors with a specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool IsFullyVectorized(this MethodInfo src, W512 w, Type tCell)
            => src.IsFullyVectorized(w) && src.ReturnType.IsVector(w,tCell);
    }
}