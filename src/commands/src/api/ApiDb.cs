//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class ApiDb 
    {
        public static ReadOnlySeq<ApiCmdRow> rows(ReadOnlySpan<CmdTypeInfo> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<ApiCmdRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                var values = ClrFields.values(instance, type.Fields.Select(x => x.Source));
                for(var j=0; j<type.FieldCount; j++,k++)
                {
                    ref var row = ref seek(dst,k);
                    ref readonly var field = ref type.Fields[j];
                    row.CmdName = type.CmdName;
                    row.FieldIndex = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.FieldName = field.Source.Name;
                    row.Expression = field.Expr;
                    row.DataType = field.Source.FieldType.DisplayName();
                    row.DefaultValue = values[field.Source.Name].Value?.ToString() ?? EmptyString;
                }
            }
            return dst;
        }

        [Record(TableId)]
        public struct ApiCmdRow
        {
            const string TableId = "api.commands";

            [Render(22)]
            public @string CmdName;

            [Render(22)]
            public @string CmdType;

            [Render(12)]
            public byte FieldIndex;

            [Render(36)]
            public @string FieldName;

            [Render(48)]
            public @string DataType;

            [Render(32)]
            public @string Expression;

            [Render(1)]
            public @string DefaultValue;
        }
    }
}