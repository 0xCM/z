//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(Table)]
    public record struct AssemblyListEntry : IComparable<AssemblyListEntry>
    {
        const string Table = "assemblies.list";

        [Render(64)]
        public @string AssemblyName;

        [Render(12)]
        public AssemblyVersion Version;

        [Render(56)]
        public Hash128 Md5Hash;

        [Render(1)]
        public FileUri Path;

        public int CompareTo(AssemblyListEntry src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
            if(result == 0)
                result = Path.CompareTo(src.Path);
            return result;
        }
    }
}