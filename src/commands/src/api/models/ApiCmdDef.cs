//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmdDef : IApiCmdDef, IComparable<ApiCmdDef>
    {
        public readonly @string CmdName;

        public readonly Type Source;

        public readonly ReadOnlySeq<CmdField> Fields;

        [MethodImpl(Inline)]
        public ApiCmdDef(string name, Type type, CmdField[] fields)
        {
            CmdName = name;
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

        Type IApiCmdDef.Source
            => Source;

        ReadOnlySeq<CmdField> IApiCmdDef.Fields
            => Fields;

        @string IApiCmdDef.CmdName
            => CmdName;

        public int CompareTo(ApiCmdDef src)
            => CmdName.CompareTo(src.CmdName);

        public string Format()
            => ApiCmd.format(this);

        public override string ToString()
            => Format();
    }
}