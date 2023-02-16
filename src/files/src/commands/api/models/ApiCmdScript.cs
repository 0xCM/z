//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ApiCmdScript
    {
        public readonly FilePath Path;

        public readonly ReadOnlySeq<ApiCmdSpec> Commands;

        public ApiCmdScript(FilePath path, params ApiCmdSpec[] src)        
        {
            Path = path;
            Commands = src;
        }

        public ApiCmdScript With(params ApiCmdSpec[] src)
            => new ApiCmdScript(Path,src);        

        public static ApiCmdScript Empty => new ApiCmdScript(FilePath.Empty, sys.empty<ApiCmdSpec>());
    }
}