//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;
    using OC = OperationKind;

    /// <summary>
    /// Classifies operators of arity up to 3
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum ApiOperatorKind : ushort
    {
        /// <summary>
        /// The empty class
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies an emitter as an operator
        /// </summary>
        Emitter = OC.Emitter,

        /// <summary>
        /// Classifies functions for which operands and return type are homogenous
        /// </summary>
        Operator = OC.Operator,

        /// <summary>
        /// Classifies operators that accept one argument
        /// </summary>
        UnaryOp = OC.UnaryOp,

        /// <summary>
        /// Classifies operators that accept two arguments
        /// </summary>
        BinaryOp = OC.BinaryOp,

        /// <summary>
        /// Classifies operators that accept three arguments
        /// </summary>
        TernaryOp = OC.TernaryOp,

        /// <summary>
        /// Classifies shift operators
        /// </summary>
        ShiftOp = OC.ShiftOp,

        /// <summary>
        /// Classifies shift operators with one operand under shift
        /// </summary>
        UnaryShiftOp = OC.UnaryShiftOp,

        /// <summary>
        /// Classifies shift operators with two operands under shift
        /// </summary>
        BinaryShiftOp = OC.BinaryShiftOp
    }
}