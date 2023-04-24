//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public AssemblyDefinition ReadAssemblyDef()
            => MD.GetAssemblyDefinition();    
    }
}