//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class WfCmdSpec
    {
        public readonly @string Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public WfCmdSpec(string name, CmdArgs args)
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
        public static implicit operator WfCmdSpec((string name, CmdArgs args) src)
            => new WfCmdSpec(src.name, src.args);

        public static WfCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new WfCmdSpec(default, CmdArgs.Empty);
        }
    }
}