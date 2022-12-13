//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdTypeInfo : ICmdTypeInfo, IComparable<CmdTypeInfo>
    {
        public readonly @string CmdName;

        public readonly Type Source;

        public readonly ReadOnlySeq<CmdField> Fields;

        [MethodImpl(Inline)]
        public CmdTypeInfo(string name, Type type, CmdField[] fields)
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

        Type ICmdTypeInfo.Source
            => Source;

        ReadOnlySeq<CmdField> ICmdTypeInfo.Fields
            => Fields;

        @string ICmdTypeInfo.CmdName
            => CmdName;

        public int CompareTo(CmdTypeInfo src)
            => CmdName.CompareTo(src.CmdName);

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
    }
}