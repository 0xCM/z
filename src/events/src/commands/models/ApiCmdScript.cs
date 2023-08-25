//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ApiCmdScript
    {
        public readonly FileUri Path;

        public readonly ReadOnlySeq<ApiCommand> Commands;

        public ApiCmdScript(FileUri path, params ApiCommand[] src)        
        {
            Path = path;
            Commands = src;
        }

        public ApiCmdScript With(params ApiCommand[] src)
            => new (Path,src);        

        public static ApiCmdScript Empty => new (FileUri.Empty, sys.empty<ApiCommand>());
    }
}