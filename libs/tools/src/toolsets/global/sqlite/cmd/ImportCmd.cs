//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        partial class Sqlite
        {
            [Cmd(CmdName)]
            public record struct ImportCmd : ICmd<ImportCmd>
            {
                const string CmdName=".import";

                public FS.FilePath Source;

                public TableId Target;

                [MethodImpl(Inline)]
                public ImportCmd(FS.FilePath src, TableId dst)
                {
                    Source = src;
                    Target = dst;
                }
            
                public string Format()
                    => $"{CmdName} {Source.Format(PathSeparator.FS)} {Target}";

                public override string ToString()
                    => Format();

                [MethodImpl(Inline)]
                public static implicit operator SqlCmd(ImportCmd src)
                    => src.Format();
            }
        }
    }
}