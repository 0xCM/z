//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record class ApiCmdSpec : IApiCmd<ApiCmdSpec>
    {
        public readonly ApiCmdRoute Route;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ApiCmdSpec()
        {
            Route = EmptyString;
            Args = CmdArgs.Empty;
        }

        [MethodImpl(Inline)]
        public ApiCmdSpec(ApiCmdRoute route, CmdArgs args)
        {
            Route = route;
            Args = args;
        }

        [MethodImpl(Inline)]
        public ApiCmdSpec(string route, CmdArgs args)
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
        public static implicit operator ApiCmdSpec((string name, CmdArgs args) src)
            => new ApiCmdSpec(src.name, src.args);

        public static ApiCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ApiCmdSpec();
        }
    }
}