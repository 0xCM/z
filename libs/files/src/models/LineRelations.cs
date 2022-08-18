//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct LineRelations : ILineRelations<LineRelations>, IComparable<LineRelations>
    {
        const string TableId = "relations";

        public const byte FieldCount = 4;

        [Render(14)]
        public LineNumber SourceLine;

        [Render(60)]
        public string Name;

        [Render(110)]
        public Lineage Ancestors;

        [Render(1)]
        public string Parameters;

        [MethodImpl(Inline)]
        public LineRelations(LineNumber line, string name, Lineage ancestors, string parameters = EmptyString)
        {
            SourceLine = line;
            Name = name;
            Ancestors = ancestors ?? Lineage.Empty;
            Parameters = parameters;
        }

        LineNumber ILineRelations.SourceLine
            => SourceLine;

        string ILineRelations.Name
            => Name;

        public string ParentName
            => Lineage.parent(Ancestors);

        public Index<string> AncestorNames
            => Lineage.ancestors(Ancestors);

        public int CompareTo(LineRelations src)
        {
            var i = Name.CompareTo(src.Name);
            if(i == 0)
                return ParentName.CompareTo(src.ParentName);
            else
                return i;
        }

        public static LineRelations Empty => new LineRelations(0, EmptyString, Lineage.Empty);
    }
}