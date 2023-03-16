//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
       public static bool IsPinvoke(MethodDefinition src)
            => src.Attributes.HasFlag(MethodAttributes.PinvokeImpl);
    }
}