//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public ReadOnlySpan<EcmaRowKey> ReadIntefaceImplKeys(TypeDefinition src)
            => src.GetInterfaceImplementations().Map(x => EcmaHandles.key(MD.GetInterfaceImplementation(x).Interface)).ToReadOnlySpan();
    }
}