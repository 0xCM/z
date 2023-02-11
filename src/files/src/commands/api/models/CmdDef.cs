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
        public CmdDef(CmdRoute name, Type type, ReadOnlySeq<CmdField> fields)
        {
            Route = name;
            Source = Require.notnull(type);
            Fields = fields;
        }
        
        public bool Field(@string name, out CmdField dst)
        {
            dst = CmdField.Empty;
            foreach(var f in Fields)
            {
                if(f.Name == name)
                {
                    dst = f;
                    break;
                }
            }

            return dst.IsNonEmpty;
        }

        public bool Field(ushort index, out CmdField dst)
        {
            if(index < Fields.Count)
                dst = Fields[index];
            else
                dst = CmdField.Empty;
            return dst.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Route.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Route.IsNonEmpty;
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

        public static CmdDef Empty => new(CmdRoute.Empty, typeof(void), sys.empty<CmdField>());
    }
}