//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Cmd;

    public record class AppCmdSpec
    {
        public readonly asci32 Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public AppCmdSpec(asci32 name, CmdArgs args)
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
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AppCmdSpec((string name, CmdArgs args) src)
            => new AppCmdSpec(src.name, src.args);

        public static AppCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new AppCmdSpec(default, CmdArgs.Empty);
        }
    }
}