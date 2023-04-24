//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {    
        [MethodImpl(Inline), Op]
        public MethodImplementation ReadMethodImpl(MethodImplementationHandle src)
            => MD.GetMethodImplementation(src);
    }
}