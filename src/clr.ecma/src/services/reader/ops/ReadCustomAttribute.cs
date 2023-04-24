//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {    
        [MethodImpl(Inline), Op]
        public System.Reflection.Metadata.CustomAttribute ReadCustomAttribute(CustomAttributeHandle src)
            => MD.GetCustomAttribute(src);
    }
}