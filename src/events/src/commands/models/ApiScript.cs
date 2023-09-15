//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public record class ApiScript
{
    public readonly FileUri Path;

    public readonly ReadOnlySeq<ApiCommand> Commands;

    public ApiScript(FileUri path, params ApiCommand[] src)        
    {
        Path = path;
        Commands = src;
    }

    public ApiScript With(params ApiCommand[] src)
        => new (Path,src);        

    public static ApiScript Empty => new (FileUri.Empty, sys.empty<ApiCommand>());
}
