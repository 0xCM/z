//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiTypeSig type(string name, params ISigTypeParam[] @params)
            => new ApiTypeSig(name, @params);
    }
}