//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static AssemblyName[] refnames(Assembly src)
            => src.GetReferencedAssemblies();
    }
}