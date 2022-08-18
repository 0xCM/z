//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Returns true if the method accepts generic parameters, false otherwise
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsOpenGeneric(this MethodInfo m)
            => m.ContainsGenericParameters;

        /// <summary>
        /// Returns true if the method has a specified count of open generic parameters, false otherwise
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsOpenGeneric(this MethodInfo m, int count)
            => m.ContainsGenericParameters && m.GenericParameters().Count() == count;

        /// <summary>
        /// Returns true if the method has unspecified generic parameters, false otherwise
        /// </summary>
        /// <param name="src">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsClosedGeneric(this MethodInfo src)
            => src.IsConstructedGenericMethod;

        /// <summary>
        /// Returns true if the method has unspecified generic parameters, false otherwise
        /// </summary>
        /// <param name="src">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsNonGeneric(this MethodInfo src)
            => !src.IsGenericMethod && !src.IsConstructedGenericMethod;

        /// <summary>
        /// Determines whether a method has a void return and, consequently, cannot be a function
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool HasVoidReturn(this MethodInfo m)
            => m.ReturnType == typeof(void);

        /// <summary>
        /// Determines whether a method has a void return
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsAction(this MethodInfo m)
            => m.HasVoidReturn();

        /// <summary>
        /// Determines whether a method is a function
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsFunction(this MethodInfo m)
            => !m.HasVoidReturn();

        /// <summary>
        /// Determines the number of parameters defined by a method
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static int ArityValue(this MethodInfo m)
            => m.GetParameters().Length;

        /// <summary>
        /// Determines whether a method has a specified arity
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="arity">The arity to match</param>
        [MethodImpl(Inline), Op]
        public static bool HasArityValue(this MethodInfo m, int arity)
            => m.ArityValue() == arity;

        /// <summary>
        /// Determines whether the method is an implicit conversion operator
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsImplicitConverter(this MethodInfo m)
            => string.Equals(m.Name, "op_Implicit", StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Determines whether the method is an explicit conversion operator
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsExplicitConverter(this MethodInfo m)
            => string.Equals(m.Name, "op_Explicit", StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Determines whether a method is an implicit or explicit conversion operation
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsConversionOperator(this MethodInfo m)
            => m.IsExplicitConverter() || m.IsImplicitConverter();

        /// <summary>
        /// Returns a method's parameter types
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static Type[] ParameterTypes(this MethodInfo m)
            => m.GetParameters().Select(p => p.ParameterType);

        /// <summary>
        /// Returns a method's parameter types
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static Type[] EffectiveParameterTypes(this MethodInfo m)
            => m.ParameterTypes().Select(t => t.EffectiveType());

        /// <summary>
        /// Returns a method's parameter types
        /// </summary>
        /// <param name="m">The method to examine</param>
        [MethodImpl(Inline), Op]
        public static Type[] ParameterTypes(this MethodInfo m, bool effective)
            => effective ? m.EffectiveParameterTypes() : m.ParameterTypes();

        /// <summary>
        /// Determines the type of an index-identified parameter
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="index">The parameter index</param>
        [MethodImpl(Inline), Op]
        public static Type ParameterType(this MethodInfo m, int index)
            => m.ArityValue() >= index + 1 ? m.GetParameters()[index].ParameterType : typeof(void);

        /// <summary>
        /// Returns true if all non-void input/output values are of the same type
        /// </summary>
        /// <param name="src">The method to examine</param>
        [Op]
        public static bool IsHomogenous(this MethodInfo src)
        {
            var inputs = src.ParameterTypes().ToHashSet();
            if(inputs.Count == 1)
                return inputs.Single() == src.ReturnType;
            else if(inputs.Count == 0)
                return src.ReturnType == typeof(void);
            else
                return false;
        }

        /// <summary>
        /// Determines whether a method defines a unary function
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsUnaryFunction(this MethodInfo m)
            => m.IsFunction() && m.HasArityValue(1);

        /// <summary>
        /// Determines whether a method is a unary operator
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsUnaryOperator(this MethodInfo m)
            => m.IsHomogenous() && m.IsUnaryFunction();

        /// <summary>
        /// Determines whether a method defines an operator over a (common) domain
        /// </summary>
        /// <param name="src">The method to examine</param>
        [Op]
        public static bool IsOperator(this MethodInfo src)
            => src.IsFunction() && src.IsHomogenous() && src.ArityValue() >= 1;

        [Op, MethodImpl(Inline)]
        public static bool IsConcrete(this MethodInfo src)
            => !src.IsAbstract && !src.ContainsGenericParameters;

        /// <summary>
        /// Determines whether a method is a binary operator
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsBinaryOperator(this MethodInfo m)
            => m.IsHomogenous() && m.IsBinaryFunction();

        /// <summary>
        /// Determines whether a method defines a binary function
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsBinaryFunction(this MethodInfo m)
            => m.IsFunction() && m.HasArityValue(2);

        /// <summary>
        /// Determines whether a method defines a binary function
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsTernaryFunction(this MethodInfo m)
            => m.IsFunction() && m.HasArityValue(3);

        /// <summary>
        /// Determines whether a method is a ternary operator
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static bool IsTernaryOperator(this MethodInfo m)
            => m.IsHomogenous() && m.IsTernaryFunction();
    }
}