//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        [MethodImpl(Inline)]
        public static OpIdentity Generalize(this OpIdentityG src)
            => ApiIdentity.opid(src.IdentityText);
    }
}