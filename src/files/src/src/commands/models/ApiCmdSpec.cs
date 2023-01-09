//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ApiCmdSpec : IApiCmd<ApiCmdSpec>
    {
        public readonly @string Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ApiCmdSpec()
        {
            Name = EmptyString;
            Args = CmdArgs.Empty;
        }

        [MethodImpl(Inline)]
        public ApiCmdSpec(string name, CmdArgs args)
        {
            Name = name;
            Args = args;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Cmd.format(this);

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