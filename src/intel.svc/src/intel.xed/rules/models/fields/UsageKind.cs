//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.RuleTableKind;

    partial class XedRules
    {
        public enum UsageKind : byte
        {
            [Symbol("ENC 0")]
            EncLeft = ENC | 0b100,

            [Symbol("ENC 1")]
            EncRight = ENC | 0b1000,

            [Symbol("DEC 0")]
            DecLeft = DEC | 0b100,

            [Symbol("DEC 1")]
            DecRight = DEC | 0b1000,
        }
    }
}