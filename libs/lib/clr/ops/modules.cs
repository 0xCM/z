//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrModuleAdapter> modules(Assembly src)
            => adapt(src.Modules());

        [MethodImpl(Inline), Op]
        public static ClrModuleAdapter manifest(Assembly src)
            => adapt(src.ManifestModule);
    }
}