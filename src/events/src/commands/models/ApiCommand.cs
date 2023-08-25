//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Specifies arguments and route required for command execution
/// </summary>
public record class ApiCommand : IApiCmd<ApiCommand>
{
    public readonly ApiCmdRoute Route;

    public readonly CmdArgs Args;

    [MethodImpl(Inline)]
    public ApiCommand()
    {
        Route = EmptyString;
        Args = CmdArgs.Empty;
    }

    [MethodImpl(Inline)]
    public ApiCommand(ApiCmdRoute route, CmdArgs args)
    {
        Route = route;
        Args = args;
    }

    [MethodImpl(Inline)]
    public ApiCommand(string route, CmdArgs args)
    {
        Route = route;
        Args = args;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Route.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Route.IsNonEmpty;
    }

    public string Format()
        => ApiServer.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator ApiCommand((string name, CmdArgs args) src)
        => new (src.name, src.args);

    public static ApiCommand Empty
    {
        [MethodImpl(Inline)]
        get => new ();
    }
}
