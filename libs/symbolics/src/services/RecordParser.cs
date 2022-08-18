//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct RecordParser : IParser<object>
    {
        readonly ReflectedTable Table;

        readonly IMultiParser Parser;

        public RecordParser(ReflectedTable table, IMultiParser parser)
        {
            Table = table;
            Parser = parser;
        }

        public Outcome Parse(string src, out object dst)
        {
            var result = Outcome.Success;
            var fields = Table.Fields;
            var count = fields.Length;
            var values = text.split(src,Chars.Pipe);
            if(values.Length != count)
            {
                dst = null;
                return (false, Tables.FieldCountMismatch.Format(fields.Length, values.Length));
            }

            try
            {
                dst = Activator.CreateInstance(Table.Type);
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref fields[i];
                    ref readonly var value = ref skip(values,i);
                    result = Parser.Parse(field.DataType, value, out var v);
                    if(result.Fail)
                    {
                        result = (false,string.Format("An attempt to parse the '{0}' field from '{1}' failed", field.MemberName, value));
                        break;
                    }

                    field.Definition.SetValue(dst, v);
                }
            }
            catch(Exception e)
            {
                result = e;
                dst = null;
            }
            return result;
        }
    }
}