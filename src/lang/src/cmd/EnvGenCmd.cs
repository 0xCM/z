//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CmdName)]
    public record class EnvGenCmd : Command<EnvGenCmd>
    {
        const string CmdName = "env/gen";

        public EnvId Name;

        public FolderPath Target;

        public EnvGenCmd()
        {
            Name = EnvId.Empty;
            Target = FolderPath.Empty;
        }
    }
}