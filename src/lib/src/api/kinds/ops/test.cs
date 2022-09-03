//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;
    using System.Reflection;

    using static Root;

    partial class VK
    {
        /// <summary>
        /// Determines whether a type is classified as an intrinsic vector
        /// </summary>
        /// <param name="t">The type to test</param>
        [Test]
        public static bool test(Type t)
        {
            var tE = t.EffectiveType();
            if(tE == null)
                return false;

            var tD = tE.IsGenericType ? tE.GetGenericTypeDefinition() : (tE.IsGenericTypeDefinition ? tE : null);
            if(tD == null)
                return false;

            return tD == typeof(Vector128<>)
                || tD == typeof(Vector256<>)
                || tD == typeof(Vector512<>);
        }

        /// <summary>
        /// Determines whether a type is an intrinsic vector of specified width
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Test]
        public static bool test(Type t, int? w)
        {
            if(!test(t))
                return false;

            if(w == null)
                return true;

            return ((int)width(t) == w);
        }

        /// <summary>
        /// Determines whether a vector of specified kind has a singed 8-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, sbyte t)
            => ((uint)k & (uint)ScalarKind.I8) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has an unsigned 8-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, byte t)
            => ((uint)k & (uint)ScalarKind.U8) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has a singed 16-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, short t)
            => ((uint)k & (uint)ScalarKind.I16) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has an unsigned 16-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, ushort t)
            => ((uint)k & (uint)ScalarKind.U16) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has a singed 32-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, int t)
             => ((uint)k & (uint)ScalarKind.I32) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has an unsigned 32-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, uint t)
            => ((uint)k & (uint)ScalarKind.U32) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has a singed 64-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, long t)
            => ((uint)k & (uint)ScalarKind.I64) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has an unsigned 64-bit cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, ulong t)
            => ((uint)k & (uint)ScalarKind.U64) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has a 32-bit floating-point cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, float t)
             => ((uint)k & (uint)ScalarKind.F32) != 0;

        /// <summary>
        /// Determines whether a vector of specified kind has a 64-bit floating-point cell type
        /// </summary>
        /// <param name="k">The vector kind</param>
        /// <param name="t">The type to match as specified by a representative value</param>
        [MethodImpl(Inline), Test]
        public static bool test(NativeVectorKind k, double t)
             => ((uint)k & (uint)ScalarKind.F64) != 0;

        /// <summary>
        /// Determines whether a type is a 128-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The vector cell type</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W128 w, Type tCell)
            => test(t,w)
            && t.IsClosedGeneric()
            && t.GenericParameters().Single() == tCell;

        /// <summary>
        /// Determines whether a type is a 256-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The vector cell type</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W256 w, Type tCell)
            => test(t,w)
            && t.IsClosedGeneric()
            && t.GenericParameters().Single() == tCell;

        /// <summary>
        /// Determines whether a type is a 512-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The vector cell type</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W512 w, Type tCell)
            => test(t,w)
            && t.IsClosedGeneric()
            && t.GenericParameters().Single() == tCell;

        /// <summary>
        /// Determines whether a type is a 128-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W128 w)
            => width(t) == NativeTypeWidth.W128;

        /// <summary>
        /// Determines whether a type is a 256-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W256 w)
            => width(t) == NativeTypeWidth.W256;

        /// <summary>
        /// Determines whether a type is a 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Test]
        public static bool test(Type t, W512 w)
            => width(t) == NativeTypeWidth.W512;

        /// <summary>
        /// Determines whether a parameter is of some intrinsic vector type
        /// </summary>
        /// <param name="p">The parameter to examine</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p)
            => test(p.ParameterType);

        /// <summary>
        /// Determines whether a parameter accepts a 128-bit intrinsic vector
        /// </summary>
        /// <param name="p">The parameter to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W128 w)
            => width(p.ParameterType) == NativeTypeWidth.W128;

        /// <summary>
        /// Determines whether a parameter accepts a 256-bit intrinsic vector
        /// </summary>
        /// <param name="p">The parameter to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W256 w)
            => width(p.ParameterType) == NativeTypeWidth.W256;

        /// <summary>
        /// Determines whether a parameter accepts a 512-bit intrinsic vector
        /// </summary>
        /// <param name="p">The parameter to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W512 w)
            => width(p.ParameterType) == NativeTypeWidth.W512;

        /// <summary>
        /// Returns true if a method parameter is a 128-bit intrinsic vector closed over a specified argument type
        /// </summary>
        /// <param name="p">The source parameter</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The argument type to match</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W128 w, Type tCell)
            => test(p.ParameterType, w, tCell);

        /// <summary>
        /// Returns true if a method parameter is a 256-bit intrinsic vector closed over a specified argument type
        /// </summary>
        /// <param name="p">The source parameter</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The argument type to match</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W256 w, Type tCell)
            => test(p.ParameterType, w, tCell);

        /// <summary>
        /// Returns true if a method parameter is a 512-bit intrinsic vector closed over a specified argument type
        /// </summary>
        /// <param name="p">The source parameter</param>
        /// <param name="w">The vector width</param>
        /// <param name="tCell">The argument type to match</param>
        [MethodImpl(Inline), Test]
        public static bool test(ParameterInfo p, W512 w, Type tCell)
            => test(p.ParameterType, w, tCell);
    }
}