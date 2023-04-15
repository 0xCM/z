//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost, Free]
    public class Datasets
    {
        public struct ColumnBuffer
        {
            public readonly TableColumns Cols;

            ArrayWriter<dynamic> Writer;

            readonly Index<dynamic> Data
            {
                [MethodImpl(Inline)]
                get => Writer.Storage;
            }

            [MethodImpl(Inline)]
            public ColumnBuffer(TableColumns cols)
            {
                Cols = cols;
                var storage = sys.alloc<dynamic>(cols.Count);
                Writer = storage.Writer();
            }

            public int Write(dynamic src)
            {
                Writer.Next() = src;
                return Writer.Pos();
            }

            public void EmitHeader(ITextBuffer dst)
            {
                dst.AppendLine(Cols.Header);
            }

            public void EmitHeader(ITextEmitter dst)
            {
                dst.AppendLine(Cols.Header);
            }

            public void EmitHeader(StreamWriter dst)
            {
                dst.AppendLine(Cols.Header);
            }

            public string Emit()
                => Format();

            public void Emit(ITextBuffer dst)
            {
                dst.Append(Emit());
            }

            public void Emit(StreamWriter dst)
            {
                dst.Append(Emit());
            }

            public void EmitLine(ITextBuffer dst)
            {
                dst.AppendLine(Emit());
            }

            public void EmitLine(ITextEmitter dst)
            {
                dst.AppendLine(Emit());
            }

            public void EmitLine(StreamWriter dst)
            {
                dst.AppendLine(Emit());
            }

            public string Format()
            {
                var content = Cols.Format(Data.Storage);
                Writer.Reset();
                return content;
            }

            public override string ToString()
                => Format();
        }

        public class TableColumns
        {
            public string TableName {get; private set;}

            Index<string> Names;

            Index<byte> Widths;

            Index<string> Slots;

            string RenderPattern;

            public readonly string Sep;

            [MethodImpl(Inline)]
            public TableColumns(string table, params (string name,byte width)[] src)
            {
                Sep = " | ";
                TableName = table;
                Widths = src.Map(x => x.width);
                Names = src.Select(x => x.name);
                Recalc();
            }

            [MethodImpl(Inline)]
            public TableColumns(params (string name,byte width)[] src)
            {
                TableName = EmptyString;
                Sep = " | ";
                Names = src.Select(x => x.name);
                Widths = src.Map(x => x.width);
                Recalc();
            }

            public TableColumns WithTableName(string name)
            {
                TableName = name;
                return this;
            }

            public string Header
                => Format(Names.Storage);

            void Recalc()
            {
                Slots = mapi(Widths, (i,w) => RP.slot((byte)i, (short)-w));
                RenderPattern = Slots.Intersperse(Sep).Concat();
            }

            public ColumnBuffer Buffer()
                => new ColumnBuffer(this);

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Names.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly string ColName(int i)
                => ref Names[i];

            [MethodImpl(Inline)]
            public ref readonly byte ColWidth(int i)
                => ref Widths[i];

            [MethodImpl(Inline)]
            public ref readonly string ColName(uint i)
                => ref Names[i];

            [MethodImpl(Inline)]
            public ref readonly byte ColWidth(uint i)
                => ref Widths[i];

            public string Format(ReadOnlySpan<object> src)
                => string.Format(RenderPattern, src.ToArray());

            public string FormatSeq(Index<object> src)
                => string.Format(RenderPattern, src.Storage);

            public string Format(object src)
                => string.Format(RenderPattern, src);

            public string Format(params object[] src)
                => string.Format(RenderPattern, src);
        }
    }
}