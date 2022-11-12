//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Symbolic
    {
        public Index<SymLiteralRow> literals(IWfChannel channel, FilePath src)
        {
            using var reader = TableConvention.reader<SymLiteralRow>(src, Symbolic.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                channel.Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return sys.empty<SymLiteralRow>();
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    channel.Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }


        public static Index<SymInfo> load(IWfChannel channel, FilePath src)
        {
            using var reader = TableConvention.reader<SymInfo>(src, parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                channel.Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return sys.empty<SymInfo>();
            }
            var dst = list<SymInfo>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    channel.Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }
    }
}