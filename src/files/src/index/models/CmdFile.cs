//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdFile : TypedFile<CmdFile,CmdFileType>
    {
        public CmdFile()
        {

        }

        public CmdFile(FilePath src)
            : base(src)
        {

        }        
    }
}