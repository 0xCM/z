
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCmd
    {
        public static void EmitCatalog(IWfChannel channel, ReadOnlySeq<Assembly> src, IDbArchive dst)
            => channel.TableEmit(rows(discover(src.Storage)), dst.Table<ApiCmdRow>());

        public static void emit(IWfChannel channel, ApiCmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            CsvChannels.emit(channel, data, dst);
        }

        public static ApiCmdCatalog catalog(ReadOnlySeq<Effector> src)
        {
            var count = src.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = src[i].Uri;
            return new ApiCmdCatalog(entries(dst));
        }

        public static ApiCmdCatalog catalog(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new ApiCmdCatalog(entries(dst));
        }

        static ReadOnlySeq<ApiCmdRow> rows(ReadOnlySpan<CmdTypeInfo> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<ApiCmdRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                var values = ClrFields.values(instance, type.Fields.Select(x => x.Source).Storage);
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

        static ReadOnlySeq<CmdTypeInfo> discover(Assembly[] src)
            => tagged(src).Select(describe).Sort();

        static Type[] tagged(Assembly src)
            =>  src.Types().Tagged<CmdAttribute>();

        static Type[] tagged(Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();

        static CmdTypeInfo describe(Type src)
            => new CmdTypeInfo(identify(src), src, fields(src));

        static string expr(FieldInfo src)
            => src.Tag<CmdArgAttribute>().MapValueOrDefault(x => text.ifempty(x.Expression,src.Name), src.Name);

        static Index<CmdField> fields(Type src)
            => src.PublicInstanceFields().Mapi((i,x) => new CmdField((byte)i, x, expr(x)));

        public static ApiCmdCatalog catalog()
            => catalog(Dispatcher);

        static ReadOnlySeq<ApiCmdInfo> entries(CmdUriSeq src)    
        {
            var entries = alloc<ApiCmdInfo>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        
    }
}