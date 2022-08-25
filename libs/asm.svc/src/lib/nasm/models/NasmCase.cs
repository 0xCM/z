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

        public FilePath SourcePath;

        public FilePath BinPath;

        public FilePath ListPath;
    }
}