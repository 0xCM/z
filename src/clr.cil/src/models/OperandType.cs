//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cil
    {
        [DataWidth(5)]
        public enum OperandType : byte
        {
            InlineBrTarget = 0,

            InlineField = 1,

            InlineI = 2,

            InlineI8 = 3,

            InlineMethod = 4,

            InlineNone = 5,

            InlinePhi = 6,

            InlineR = 7,

            InlineSig = 9,

            InlineString = 10,

            InlineSwitch = 11,

            InlineTok = 12,

            InlineType = 13,

            InlineVar = 14,

            ShortInlineBrTarget = 15,

            ShortInlineI = 16,

            ShortInlineR = 17,

            ShortInlineVar = 18,
        }
    }
}