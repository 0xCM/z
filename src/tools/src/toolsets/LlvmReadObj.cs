//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    class ReadObjFlow : ToolFlow<ReadObjFlow>
    {
        public ReadObjFlow()
        {}

    }

    class LlvmReadObj : ToolWfCmd<LlvmReadObj,ReadObjFlow>
    {
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-readobj");

        protected override bool Include(FilePath src)
            => src.Is(FileKind.Exe) || src.Is(FileKind.Obj) || src.Is(FileKind.Dll);

        [CmdOp("lib/exports")]
        void CoffExports(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = Archives.index(src, FileKind.Lib);
            var dst = EnvDb.Nested("coff", src.Root).Clear();
            var command = Tooling.command(ToolPath, Tooling.flag(ArgPrefixKind.Dashes,"coff-exports"));
            iter(index.Distinct(), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("lib.exports"));
                Run(command, dst.Path(filename));
            }, true);
        }
    }
}
