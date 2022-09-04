//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class XApi
    {
        /// <summary>
        /// Enables the assembly indicator
        /// </summary>
        [Op]
        public static _OpIdentity WithAsm(this _OpIdentity src)
        {
            if(src.IdentityText.Contains(IDI.AsmLocator))
                return src;
            else
                return ApiIdentity.opid(src.IdentityText + IDI.AsmLocator);
        }
    }
}