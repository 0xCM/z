//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;
    using static BitLogix;

    using BLK = BinaryBitLogicKind;

    partial class BitLogixOps
    {
        /// <summary>
        /// Returns a kind-identified binary operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static BinaryOp<bit> lookup(BLK kind)
        {
            switch(kind)
            {
                case BLK.True: return @true;
                case BLK.False: return @false;
                case BLK.And: return and;
                case BLK.Nand: return nand;
                case BLK.Or: return or;
                case BLK.Nor: return nor;
                case BLK.Xor: return xor;
                case BLK.Xnor: return xnor;
                case BLK.Left: return left;
                case BLK.Right: return right;
                case BLK.LNot: return lnot;
                case BLK.RNot: return rnot;
                case BLK.Impl: return impl;
                case BLK.NonImpl: return nonimpl;
                case BLK.CImpl: return cimpl;
                case BLK.CNonImpl: return cnonimpl;
                default: throw Unsupported.value(sig(kind));
            }
        }
    }
}