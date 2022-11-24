//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public PropertyDefinition ReadPropertyDef(PropertyDefinitionHandle src)
            => MD.GetPropertyDefinition(src);
    }
}