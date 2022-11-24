//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitList(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            Channel.Write(src.Root);
            iter(src.Enumerate(true, FileKind.Dll, FileKind.Exe), file => {
                {
                    try
                    {
                        using var ecma = EcmaFile.open(file);
                        var reader = ecma.Reader();
                        Channel.Row(ecma.Uri);
                        foreach(var f in reader.ReadDocInfo())
                            Channel.Write($"{f.ContentHash} | {f.Name}");                            
                    }
                    catch(Exception e)
                    {
                        Channel.Error(e);
                    }
                }
            },false);
        }
    }
}