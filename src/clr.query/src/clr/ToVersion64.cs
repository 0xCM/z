//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static Version64 ToVersion64(this AssemblyVersion src)
            => sys.@as<AssemblyVersion,Version64>(src);

    }
}