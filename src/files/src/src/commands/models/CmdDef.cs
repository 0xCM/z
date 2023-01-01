//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdDef : IComparable<CmdDef>
    {
        public readonly CmdRoute Route;

        public readonly Type Source;

        public readonly ReadOnlySeq<CmdField> Fields;

        [MethodImpl(Inline)]
        public CmdDef(CmdRoute name, Type type, CmdField[] fields)
        {
            Route = name;
            Source = Require.notnull(type);
            Fields = fields;
        }

        public string TypeName
        {
            [MethodImpl(Inline)]
            get => Source.DisplayName();
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        public int CompareTo(CmdDef src)
            => Route.CompareTo(src.Route);

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
    }
}