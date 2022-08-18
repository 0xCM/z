//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using M = SdmModels.SdmEncodingSigs;

    partial struct SdmModels
    {
        public enum ModRmEncKind : byte
        {
            [Symbol(M.ModRm_RmR)]
            RmR,

            [Symbol(M.ModRm_RmW)]
            RmW,

            [Symbol(M.ModRm_RmRW)]
            RmRW,

            [Symbol(M.ModRm_RegR)]
            RegR,

            [Symbol(M.ModRm_RegW)]
            RegW,

            [Symbol(M.ModRm_RegRW)]
            RegRW,

            [Symbol(M.ModRm_RmR11)]
            RmRMust11,

            [Symbol(M.ModRm_RmWNot11)]
            RmWNot11
        }
    }
}