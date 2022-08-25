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

        public FilePath ImgPath;

        public FilePath PdbPath;

        public FilePath XmlPath;

        public ByteSize MetadatSize;
    }
}