//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    partial class XApi
    {
        /// <summary>
        /// Enables the generic indicator
        /// </summary>
        [Op]
        public static _OpIdentity WithGeneric(this _OpIdentity src)
        {
            if(src.Components.Skip(1).First()[0] == IDI.Generic)
                return src;
            else
               return ApiIdentity.opid(
                   string.Concat(src.IdentityText.LeftOfFirst(IDI.PartSep), IDI.PartSep, IDI.Generic,  src.IdentityText.RightOfFirst(IDI.PartSep)));
        }
    }
}