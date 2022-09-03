//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;


    public class TableReader<T> : IDisposable
        where T : struct
    {
        readonly StreamReader Stream;

        readonly string HeaderText;

        uint Counter;

        readonly RowParser<T> Parser;

        public TableReader(FilePath src, bool header = true)
        {
            Stream = src.Utf8Reader();
            if(header)
            HeaderText = header ? Stream.ReadLine() : EmptyString;
            Counter = 1;
            Parser = DefaultParser;
        }

        public TableReader(FilePath src, RowParser<T> parser, bool header = true)
        {
            Stream = src.Utf8Reader();
            if(header)
            HeaderText = header ? Stream.ReadLine() : EmptyString;
            Counter = 1;
            Parser = parser;
        }

        public bool Complete => Stream.EndOfStream;

        Outcome DefaultParser(string src, out T dst)
        {
            dst = default;
            return false;
        }

        public Outcome ReadLine(out TextLine dst)
        {
            if(!Stream.EndOfStream)
            {
                dst = (Counter++, Stream.ReadLine());
                return true;
            }
            else
            {
                dst = TextLine.Empty;
                return false;
            }
        }

        public Outcome ReadRow(out T dst)
        {
            if(ReadLine(out var line))
                return Parser(line.Content, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public string Header
        {
            get => HeaderText;
        }


        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}