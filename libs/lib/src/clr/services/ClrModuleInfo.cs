//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClrModuleInfo
    {
        public const string TableId = "clr.modules";

        public FS.FilePath ImgPath;

        public FS.FilePath PdbPath;

        public FS.FilePath XmlPath;

        public ByteSize MetadatSize;
    }
}