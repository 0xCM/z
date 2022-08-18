//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [Op]
        public static string assign(object lhs, object rhs, bool spaced = true)
            => string.Format(spaced ? RpOps.SpacedAssign : RpOps.Assign, lhs, rhs);
    }
}