//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmCase
    {
        public const string TableId = "nasm.case";

        public Identifier CaseId;

        public FS.FilePath SourcePath;

        public FS.FilePath BinPath;

        public FS.FilePath ListPath;
    }
}