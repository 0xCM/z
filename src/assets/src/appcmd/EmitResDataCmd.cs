//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct EmitResDataCmd : ICmd<EmitResDataCmd>
    {
        public const string CmdName = "emit-res-data";

        public Assembly Source;

        public FolderPath Target;

        public utf8 Match;

        public bool ClearTarget;
    }
}