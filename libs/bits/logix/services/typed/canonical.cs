//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using BLK = BinaryBitLogicKind;

    partial struct TypedLogicSpec
    {
        /// <summary>
        /// Defines a typed literal where all bits are on
        /// </summary>
        /// <typeparam name="T">The literal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LogixLiteral<T> @true<T>()
            where T : unmanaged
                => Limits.maxval<T>();

        /// <summary>
        /// Defines a typed literal where all bits are off
        /// </summary>
        /// <typeparam name="T">The literal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LogixLiteral<T> @false<T>()
            where T : unmanaged
                => default(T);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LogixLiteral<Vector256<T>> @false<T>(N256 n)
            where T : unmanaged
                => literal(default(Vector256<T>));

        /// <summary>
        /// Defines a bitwise and expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> and<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BLK.And, lhs,rhs);

        /// <summary>
        /// Defines a bitwise and expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> and<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.And, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines a bitwise or expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> or<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BLK.Or, lhs,rhs);

        /// <summary>
        /// Defines a bitwise or expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> or<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.Or, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines a bitwise xor expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> xor<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BLK.Xor, lhs,rhs);

        /// <summary>
        /// Defines a bitwise xor expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> xor<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.Xor, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines a a bitwise complement expression
        /// </summary>
        /// <param name="operand">The expression operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryBitwiseOpExpr<T> not<T>(ILogixExpr<T> operand)
            where T : unmanaged
                => unary(UnaryBitLogicKind.Not, operand);

        /// <summary>
        /// Defines a a bitwise complement expression with a literal operand
        /// </summary>
        /// <param name="operand">The expression operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryBitwiseOpExpr<T> not<T>(T operand)
            where T : unmanaged
                => unary(UnaryBitLogicKind.Not, literal(operand));

        /// <summary>
        /// Defines a bitwise NAND expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> nand<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BinaryBitLogicKind.Nand, lhs,rhs);

        /// <summary>
        /// Defines a bitwise NAND expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> nand<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.Nand, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines a bitwise NOR expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> nor<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BLK.Nor, lhs,rhs);

        /// <summary>
        /// Defines a bitwise NOR expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> nor<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.Nor, literal(lhs), literal(rhs));

        /// <summary>
        /// Defines a bitwise XNOR expression
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> xnor<T>(ILogixExpr<T> lhs, ILogixExpr<T> rhs)
            where T : unmanaged
                => binary(BLK.Xnor, lhs,rhs);

        /// <summary>
        /// Defines a bitwise XNOR expression with literal operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryBitwiseOpExpr<T> xnor<T>(T lhs, T rhs)
            where T : unmanaged
                => binary(BLK.Xnor, literal(lhs), literal(rhs));
    }
}