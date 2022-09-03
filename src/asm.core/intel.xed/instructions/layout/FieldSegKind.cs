//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldSegKind : byte
        {
            None,

            [Symbol("mm")]
            Mod,

            [Symbol("rrr")]
            Reg,

            [Symbol("nnn")]
            Rm,

            [Symbol("rrr")]
            Srm
        }
    }
}