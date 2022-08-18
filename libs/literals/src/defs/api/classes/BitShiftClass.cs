//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;


    using Id = ApiClassKind;

    /// <summary>
    /// Classifies bitwise shift operators
    /// </summary>
    [ApiClass, SymSource(api_classes)]
    public enum BitShiftClass : ushort
    {
        /// <summary>
        /// The empty identity
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies logical left-shift operators
        /// </summary>
        [Symbol("sll")]
        Sll = Id.Sll,

        /// <summary>
        /// Classifies variable logical left-shift operators
        /// </summary>
        [Symbol("sllv")]
        Sllv = Id.Sllv,

        /// <summary>
        /// Classifies logical right-shift operators
        /// </summary>
        [Symbol("srl")]
        Srl = Id.Srl,

        /// <summary>
        /// Classifies variable logical right-shift operators
        /// </summary>
        [Symbol("srlv")]
        Srlv = Id.Srlv,

        /// <summary>
        /// Classifies arithmetic left-shift operators
        /// </summary>
        [Symbol("sal")]
        Sal = Id.Sal,

        /// <summary>
        /// Classifies arithmetic right-shift operators
        /// </summary>
        [Symbol("sra")]
        Sra = Id.Sra,

        /// <summary>
        /// Classifies left circular shift operators
        /// </summary>
        [Symbol("rotl")]
        Rotl = Id.Rotl,

        /// <summary>
        /// Classifies right circular shift operators
        /// </summary>
        [Symbol("rotr")]
        Rotr  = Id.Rotr,

        /// <summary>
        /// Classifies segmented right circular shift operators with potentially varying shift amounts per segment
        /// </summary>
        [Symbol("rotrv")]
        Rotrv  = Id.Rotrv,

        /// <summary>
        /// Classifies segmented left circular shift operators with potentially varying shift amounts per segment
        /// </summary>
        [Symbol("rotlv")]
        Rotlv  = Id.Rotlv,

        /// <summary>
        /// Classifies composite shift operators of the form a^(a << offset)
        /// </summary>
        [Symbol("xorsl")]
        XorSl = Id.XorSl,

        /// <summary>
        /// Classifies composite shift operators of the form a^(a >> offset)
        /// </summary>
        [Symbol("xorsr")]
        XorSr = Id.XorSr,

        /// <summary>
        /// Classifies composite shift operators of the form a ^ ((a << offset) ^ (a >> offset))
        /// </summary>
        [Symbol("xors")]
        Xors = Id.Xors,

        [Symbol("bsrl")]
        Bsrl = Id.Bsrl,

        [Symbol("bsll")]
        Bsll = Id.Bsll,

        [Symbol("rotrx")]
        Rotrx = Id.Rotrx,

        [Symbol("rotlx")]
        Rotlx = Id.Rotlx,

        [Symbol("sllx")]
        Sllx = Id.Sllx,

        [Symbol("srlx")]
        Srlx = Id.Srlx,
    }
}