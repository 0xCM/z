//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        [Record(TableName)]
        public record class DependencyRecord : IComparable<DependencyRecord>
        {
            const string TableName = "jsondeps";

            [Render(16)]
            public string Type;

            [Render(82)]
            public ComponentKey Source;

            [Render(82)]
            public ComponentKey Target;

            [Render(1)]
            public FilePath JsonFile;
            public int CompareTo(DependencyRecord src)
            {
                var result = Source.CompareTo(src.Source);
                if(result == 0)
                {
                    result = Target.CompareTo(src.Target);
                }
                return result;
            }
        }
    }
}