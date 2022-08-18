//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiOpenSigParam open(ushort position, string name)
            => new ApiOpenSigParam(position, name);

        [MethodImpl(Inline), Op]
        public static ApiClosedSigParam close(ApiOpenSigParam src, ApiTypeSig closure)
            => new ApiClosedSigParam(src.Position, src.Name, closure);
    }
}