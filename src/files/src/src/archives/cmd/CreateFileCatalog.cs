
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    public record class CreateFileCatalog : Command<CreateFileCatalog>
    {
        public CreateFileCatalog()
        {
            Source = FolderPath.Empty;
            Target = FolderPath.Empty;
            Match = sys.empty<FileExt>();
        }

        public FolderPath Source;

        public FolderPath Target;

        public Seq<FileExt> Match;

    }
}