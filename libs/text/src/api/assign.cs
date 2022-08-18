//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [Op]
        public static string assign(object lhs, object rhs, bool spaced = true)
            => string.Format(spaced ? RP.SpacedAssign : RP.Assign, lhs, rhs);
    }
}