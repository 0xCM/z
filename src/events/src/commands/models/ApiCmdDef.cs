//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class ApiCmdDef : IComparable<ApiCmdDef>
    {
        [Op]
        public static string format(ApiCmdDef src)
        {
            var buffer = text.buffer();
            render(src, buffer);
            return buffer.Emit();
        }

        [Op]
        static void render(ApiCmdDef src, ITextBuffer dst)
        {
            dst.Append(src.Source.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.Name, field.Description));
            }
        }

        public readonly ApiCmdRoute Route;

        public readonly Type Source;

        public readonly ReadOnlySeq<CmdField> Fields;

        [MethodImpl(Inline)]
        public ApiCmdDef(ApiCmdRoute name, Type type, ReadOnlySeq<CmdField> fields)
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

        public int CompareTo(ApiCmdDef src)
            => Route.CompareTo(src.Route);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static ApiCmdDef Empty => new(ApiCmdRoute.Empty, typeof(void), sys.empty<CmdField>());
    }
}