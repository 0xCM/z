//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FilePath DllPath(this AssemblyName src, FS.FolderPath dir)
            => dir + FS.file(src.SimpleName(), FS.Dll);

        [MethodImpl(Inline), Op]
        public static AssemblyName[] ReferenceNames(this Assembly src)
            => Clr.refnames(src);
    }
}