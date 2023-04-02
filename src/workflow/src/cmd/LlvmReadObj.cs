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
            : base("llvm-readobj")
        {}

    }

    class LlvmReadObj : ToolWfCmd<LlvmReadObj,ReadObjFlow>
    {
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-readobj");

        protected override bool Include(FilePath src)
            => src.Is(FileKind.Exe) || src.Is(FileKind.Obj) || src.Is(FileKind.Dll);

        [CmdOp("llvm/readobj/exports")]
        void CoffExports(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-readobj", src.Root).Clear();
            iter(Sources(args), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("exports"));                
                Run(Cmd.args(entry.Path.Format(PathSeparator.FS), "--coff-exports"), entry.Path, dst.Path(filename));
            }, true);
        }
    }
}