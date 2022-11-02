//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ArchiveRegistry : WfSvc<ArchiveRegistry>
    {
        FilePath RegistryPath => AppDb.Settings("workspaces", FileKind.Csv);

        ICsvFormatter<Entry> EntryFormatter = Tables.formatter<Entry>();

        public void Register(@string name, FolderPath location)
        {
            using var writer = RegistryPath.Writer();
            writer.AppendLine(EntryFormatter.Format(new Entry(name, location.ToUri())));
        }

        public ReadOnlySpan<Entry> Entries()
        {
            using var reader = RegistryPath.Utf8Reader();
            var line = reader.ReadLine();
            var counter = 0u;
            var dst = list<Entry>();
            while(nonempty(line))
            {
                var parts = text.split(line, Chars.Pipe);
                if(parts.Length != 2)
                    sys.@throw("Parse failure");                    
                dst.Add(new Entry(skip(parts,0), new FileUri(skip(parts,1))));
                line = reader.ReadLine();
            }
            return dst.ViewDeposited();
        }

        public readonly struct Entry
        {
            public readonly @string Name;

            public readonly FileUri Location;

            [MethodImpl(Inline)]
            public Entry(@string name, FileUri uri)
            {
                Name = name;
                Location = uri;
            }
        }
    }
}