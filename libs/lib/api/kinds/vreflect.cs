//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    [ApiHost]
    public readonly struct vreflect
    {
        /// <summary>
        /// Determines whether a type is classified as an intrinsic vector
        /// </summary>
        /// <param name="t">The type to test</param>
        [Op]
        public static bool IsVector(Type t)
        {
            var eff = t.EffectiveType();
            var def = eff.IsGenericType ? eff.GetGenericTypeDefinition() : (eff.IsGenericTypeDefinition ? eff : null);
            if(def == null)
                return false;

            return def == typeof(Vector128<>) || def == typeof(Vector256<>) || def.Tagged<VectorAttribute>();
        }

        /// <summary>
        /// Determines whether a method accepts an intrinsic vector in some parameter slot
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src)
            => src.Parameters(p => p.IsVector()).Any();

        /// <summary>
        /// Determines whether a method accepts an intrinsic vector at an index-identified parameter
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index)
            => src.Parameters(p => p.Position == index && p.IsVector()).Any();

        /// <summary>
        /// Determines whether a method accepts a 128-bit intrinsic vector at an index-identified parameter
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W512 w)
            => src.Parameters(p => p.Position == index && p.IsVector(w)).Any();

        /// <summary>
        /// Determines whether a method accepts a 128-bit intrinsic vector at an index-identified parameter of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W128 w, Type tCell)
            => src.Parameters(p => p.Position == index && p.IsVector(w,tCell)).Any();

        /// <summary>
        /// Determines whether a method accepts a 128-bit intrinsic vector at an index-identified parameter
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W128 w)
            => src.Parameters(p => p.Position == index && p.IsVector(w)).Any();

        /// <summary>
        /// Determines whether a method accepts a 128-bit intrinsic vector at an index-identified parameter
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W256 w)
            => src.Parameters(p => p.Position == index && p.IsVector(w)).Any();

        /// <summary>
        /// Determines whether a method accepts a 256-bit intrinsic vector at an index-identified parameter of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">THe parameter index to match</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W256 w, Type tCell)
            => src.Parameters(p => p.Position == index && p.IsVector(w,tCell)).Any();

        /// <summary>
        /// Determines whether a method accepts a 512-bit intrinsic vector at an index-identified parameter of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="index">The parameter index to match</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool AcceptsVector(MethodInfo src, int index, W512 w, Type tCell)
            => src.Parameters(p => p.Position == index && p.IsVector(w,tCell)).Any();

        /// <summary>
        /// Determines whether a method returns a 128-bit intrinsic vector
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W128 w)
            => src.ReturnType.IsVector(w);

        /// <summary>
        /// Determines whether a method returns a 256-bit intrinsic vector
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W256 w)
            => src.ReturnType.IsVector(w);

        /// <summary>
        /// Determines whether a method returns a 256-bit intrinsic vector
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W512 w)
            => src.ReturnType.IsVector(w);

        /// <summary>
        /// Determines whether a method returns a 128-bit intrinsic vector of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W128 w, Type tCell)
            => src.ReturnType.IsVector(w, tCell);

        /// <summary>
        /// Determines whether a method returns a 256-bit intrinsic vector of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W256 w, Type tCell)
            => src.ReturnType.IsVector(w, tCell);

        /// <summary>
        /// Determines whether a method returns a 512-bit intrinsic vector with of specified cell type
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="w">The width to match</param>
        /// <param name="tCell">The cell type to match</param>
        [Op]
        public static bool ReturnsVector(MethodInfo src, W512 w, Type tCell)
            => src.ReturnType.IsVector(w, tCell);

        /// <summary>
        /// Determines whether a method has intrinsic paremeters or return type of specified width
        /// </summary>
        /// <param name="src">The method to test</param>
        /// <param name="width">The required vector width</param>
        /// <param name="total">Whether all parameters and return type must be intrinsic</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, int? width, bool total)
            => total ? (VK.test(src.ReturnType,width) && src.ParameterTypes().All(t => VK.test(t,width)))
                     : (VK.test(src.ReturnType,width) || src.ParameterTypes().Any(t => VK.test(t,width)));

        /// <summary>
        /// Determines whether a method has intrinsic parameters or return type
        /// </summary>
        /// <param name="src">The method to test</param>
        [Op]
        public static bool IsVectorized(MethodInfo src)
            => src.ReturnType.IsVector() || src.ParameterTypes().Any(VK.test);

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo m, W128 w)
            => IsVectorized(m) && m.Parameters(p => p.ParameterType.IsVector(w)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo m, W256 w)
            => IsVectorized(m) && m.Parameters(p => p.ParameterType.IsVector(w)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W512 w)
            => IsVectorized(src) && src.Parameters(p => p.ParameterType.IsVector(w)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 128-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W128 w, Type tCell)
            => IsVectorized(src) && src.Parameters(p => p.ParameterType.IsVector(w,tCell)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 256-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W256 w, Type tCell)
            => IsVectorized(src) && src.Parameters(p => p.ParameterType.IsVector(w,tCell)).Count() != 0;

        /// <summary>
        /// Determines whether a method has at least one 512-bit intrinsic vector parameter closed over a specified type
        /// </summary>
        /// <param name="src">The method to examine</param>
        /// <param name="w">The width to match</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W512 w, Type tCell)
            => IsVectorized(src,w) && src.Parameters(p => p.ParameterType.IsVector(w,tCell)).Count() != 0;

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W128 w, GenericState g = default)
            => IsVectorized(src,w) && src.IsMemberOf(g);

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W256 w, GenericState g = default)
            => IsVectorized(src, w) && src.IsMemberOf(g);

        /// <summary>
        /// Selects vectorized methods from a source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="w">The vector width</param>
        /// <param name="g">The generic partition from which methods should be selected</param>
        [Op]
        public static bool IsVectorized(MethodInfo src, W512 w, GenericState g = default)
            => src.IsVectorized(w) && src.IsMemberOf(g);
    }
}