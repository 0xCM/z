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
        public ExportedType ReadExportedType(ExportedTypeHandle src)
            => MD.GetExportedType(src);

    }
}
