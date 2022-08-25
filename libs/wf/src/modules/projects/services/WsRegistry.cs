//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WsRegistry : WfSvc<WsRegistry>
    {
        FilePath RegistryPath => AppDb.Settings("workspaces", FileKind.Csv);

        IRecordFormatter<Entry> EntryFormatter = Tables.formatter<Entry>();

        public void Register(Name name, FS.FolderPath location)
        {
            using var writer = RegistryPath.Writer();
            writer.AppendLine(EntryFormatter.Format(new Entry(name,new Uri(location.ToUri().Format()))));
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
                dst.Add(new Entry(skip(parts,0), new Uri(skip(parts,1))));
                line = reader.ReadLine();
            }
            return dst.ViewDeposited();
        }

        public readonly struct Entry
        {
            public readonly Name Name;

            public readonly Uri Location;

            [MethodImpl(Inline)]
            public Entry(Name name, Uri loc)
            {
                Name = name;
                Location = loc;
            }
        }
    }
}