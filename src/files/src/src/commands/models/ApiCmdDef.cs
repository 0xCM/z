//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmdDef : IComparable<ApiCmdDef>
    {
        public readonly @string Path;

        public readonly Type Source;

        public readonly ReadOnlySeq<CmdField> Fields;

        [MethodImpl(Inline)]
        public ApiCmdDef(string name, Type type, CmdField[] fields)
        {
            Path = name;
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


        public int CompareTo(ApiCmdDef src)
            => Path.CompareTo(src.Path);

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
    }
}