//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdFileType : FileType<CmdFileType>
    {
        public CmdFileType()
            : base("cmd")
        {

        }

        public override FileExt Ext 
            => FS.ext("cmd");
    }
}