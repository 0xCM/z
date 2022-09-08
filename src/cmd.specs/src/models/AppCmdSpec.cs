//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class AppCmdSpec
    {
        public readonly @string Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public AppCmdSpec(string name, CmdArgs args)
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
            => CmdFormat.format(this);

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