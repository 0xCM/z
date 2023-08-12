//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ApiCmdScript
    {
        public readonly FileUri Path;

        public readonly ReadOnlySeq<ApiCmdSpec> Commands;

        public ApiCmdScript(FileUri path, params ApiCmdSpec[] src)        
        {
            Path = path;
            Commands = src;
        }

        public ApiCmdScript With(params ApiCmdSpec[] src)
            => new (Path,src);        

        public static ApiCmdScript Empty => new (FileUri.Empty, sys.empty<ApiCmdSpec>());
    }
}