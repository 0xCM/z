//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PeReader
    {
        [Op]
        public AssemblyName AssemblyName()
            => MD.GetAssemblyDefinition().GetAssemblyName();
    }
}