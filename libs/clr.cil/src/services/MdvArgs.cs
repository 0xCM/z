//-----------------------------------------------------------------------------
// Copyright   :  Microsoft
// License     :  Apache
//-----------------------------------------------------------------------------
namespace System.Reflection.Metadata
{
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;

    public sealed class MdvArgs
    {
        public static MdvArgs create(string src, string dst)
            => new MdvArgs{
                Path = src,
                OutputPath = dst
            };

        public string Path { get; set; }

        public string OutputPath { get; set; }

        public bool Recursive { get; set; }
            = false;

        public IReadOnlyList<(string MetadataPath, string ILPathOpt)> EncDeltas { get; set; }
            = new List<(string MetadataPath, string ILPathOpt)>();

        public HashSet<int> SkipGenerations { get; set; }
            = new HashSet<int>();

        public bool DisplayStatistics { get; set; }
            = true;

        public bool DisplayAssemblyReferences { get; set; }
            = true;

        public bool DisplayIL { get; set; }
            = true;

        public bool DisplayEmbeddedPdb { get; set; }
            = false;

        public bool DisplayMetadata { get; set; }
            = true;

        public ImmutableArray<string> FindRefs { get; set; }
            = ImmutableArray<string>.Empty;

        public const string Help = @"
    Parameters:
    <path>                                    Path to a PE file, metadata blob, or a directory.
                                            The target kind is auto-detected.
    /g:<metadata-delta-path>;<il-delta-path>  Add generation delta blobs.
    /sg:<generation #>                        Suppress display of specified generation.
    /stats[+|-]                               Display/hide misc statistics.
    /assemblyRefs[+|-]                        Display/hide assembly references.
    /il[+|-]                                  Display/hide IL of method bodies.
    /md[+|-]                                  Display/hide metadata tables.
    /embeddedpdb[+|-]                         Display embedded PDB insted of the type system metadata.
    /findRef:<MemberRefs>                     Displays all assemblies containing the specified MemberRefs:
                                            a semicolon separated list of
                                            <assembly display name>:<qualified-type-name>:<member-name>
    /out:<path>                               Write the output to specified file.

    If the target path is a directory displays information for all *.dll, *.exe, *.winmd,
    and *.netmodule files in the directory and all subdirectories.

    If /g is specified the path must be baseline PE file (generation 0).
    ";

        public static MdvArgs TryParse(string[] args)
        {
            if (args.Length < 1)
            {
                return null;
            }

            var result = new MdvArgs();
            result.Path = args[0];
            result.Recursive = Directory.Exists(args[0]);

            result.EncDeltas =
                (from arg in args
                where arg.StartsWith("/g:", StringComparison.Ordinal)
                let value = arg.Substring("/g:".Length).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                select (value.Length >= 1 && value.Length <= 2) ? (value[0], value.Length > 1 ? value[1] : null) : default((string, string))).
                ToArray();

            if (result.EncDeltas.Any(value => value.MetadataPath == null))
            {
                return null;
            }

            result.SkipGenerations = new HashSet<int>(args.Where(a => a.StartsWith("/sg:", StringComparison.OrdinalIgnoreCase)).Select(a => int.Parse(a.Substring("/sg:".Length))));

            if (result.Recursive && (result.EncDeltas.Any() || result.SkipGenerations.Any()))
            {
                return null;
            }

            result.FindRefs = ParseValueArg(args, "findref")?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)?.ToImmutableArray() ?? ImmutableArray<string>.Empty;
            bool findRefs = result.FindRefs.Any();

            result.DisplayIL = ParseFlagArg(args, "il", defaultValue: !result.Recursive && !findRefs);
            result.DisplayMetadata = ParseFlagArg(args, "md", defaultValue: !result.Recursive && !findRefs);
            result.DisplayEmbeddedPdb = ParseFlagArg(args, "embeddedpdb", defaultValue: false);
            result.DisplayStatistics = ParseFlagArg(args, "stats", defaultValue: result.Recursive && !findRefs);
            result.DisplayAssemblyReferences = ParseFlagArg(args, "stats", defaultValue: !findRefs);
            result.OutputPath = ParseValueArg(args, "out");

            if (result.DisplayEmbeddedPdb && result.EncDeltas.Count > 0)
            {
                return null;
            }

            return result;
        }

        private static string ParseValueArg(string[] args, string name)
        {
            string prefix = "/" + name + ":";
            return args.Where(arg => arg.StartsWith(prefix, StringComparison.Ordinal)).Select(arg => arg.Substring(prefix.Length)).LastOrDefault();
        }

        private static bool ParseFlagArg(string[] args, string name, bool defaultValue)
        {
            string onStr1 = "/" + name;
            string onStr2 = "/" + name + "+";
            string offStr = "/" + name + "-";

            return args.Aggregate(defaultValue, (value, arg) =>
                arg.Equals(onStr1, StringComparison.OrdinalIgnoreCase) || arg.Equals(onStr2, StringComparison.OrdinalIgnoreCase) ? true :
                arg.Equals(offStr, StringComparison.OrdinalIgnoreCase) ? false :
                value);
        }
    }
}