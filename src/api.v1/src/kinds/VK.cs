//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    [ApiHost]
    public static partial class XVK
    {
        const NumericKind Closure = UnsignedInts;
    }

    [ApiHost]
    public partial class VK
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Closed vector types of width 128
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types128()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector128<>).MakeGenericType(t));

        /// <summary>
        /// Closed vector types of width 256
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types256()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector256<>).MakeGenericType(t));

        /// <summary>
        /// Closed vector types of width 512
        /// </summary>
        [Op]
        public static ReadOnlySpan<Type> Types512()
            => NumericKinds.NumericTypes().Select(t => typeof(Vector512<>).MakeGenericType(t));


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
    }
}