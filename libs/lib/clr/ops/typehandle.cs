//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static RuntimeTypeHandle typehandle(Module src, CliToken token)
            => src.ModuleHandle.GetRuntimeTypeHandleFromMetadataToken((int)token);
    }
}