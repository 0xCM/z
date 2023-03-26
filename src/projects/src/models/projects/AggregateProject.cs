//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    partial class ProjectModels
    {
        public sealed record class AggregateProject : Project<AggregateProject>
        {
            public AggregateProject()
                : base(ProjectKind.Aggregate, FolderPath.Empty)
            {

            }

            public AggregateProject(FilePath path)
                : base(ProjectKind.Aggregate, path.FolderPath)
            {
                JsonDoc = Json.document(path.ReadBytes());                                
            }

            public JsonDocument JsonDoc {get;}

            public ReadOnlySeq<FolderPath> Files {get;}
        }
    }
}