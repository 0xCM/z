
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        public ReadOnlySeq<ModuleRefRow> ReadModuleRefs()
            => from h in ModuleRefHandles() select new ModuleRefRow(h, MD.GetModuleReference(h).Name);
    }
}