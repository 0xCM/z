//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op]
        public static ref readonly Assembly controller()
            => ref ExecutingPart.Assembly;
   }
}