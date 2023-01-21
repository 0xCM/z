//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct RecordParser : IParser<object>
    {
        readonly ClrTable Table;

        readonly IMultiParser Parser;

        public RecordParser(ClrTable table, IMultiParser parser)
        {
            Table = table;
            Parser = parser;
        }

        public Outcome Parse(string src, out object dst)
        {
            var result = Outcome.Success;
            var slots = Table.Cells;
            var count = slots.Length;
            var values = text.split(src,Chars.Pipe);
            if(values.Length != count)
            {
                dst = null;
                return (false, AppMsgs.FieldCountMismatch.Format(slots.Length, values.Length));
            }

            try
            {
                dst = Activator.CreateInstance(Table.Type);
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref slots[i];
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