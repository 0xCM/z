//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    [ApiHost]
    public class SeqParserChecks : Checker<SeqParserChecks>
    {
        [Op]
        void Exec()
        {
            var a = test(n0).Format();
            var b = test(n1).Format();
            var c = test(n2).Format();
        }

        [Op]
        BufferSegments<char> test(N0 n)
        {
            const string Input = "323,3333,33,1";
            const char Delimiter = ',';
            const byte SegCount = 4;
            var parser = ApiParsers.splitter(Delimiter);
            var input = edit(span(Input));
            ApiParsers.split(parser, input, out var segments);
            return segments;
        }

        [Op]
        BufferSegments<ushort> test(N1 n)
        {
            const string Input = "90.33.33.391.385.9";
            const char Delimiter = '.';
            const byte SegCount = 6;

            var parser = ApiParsers.splitter<ushort>(Delimiter);
            var input = uint16(edit(span(Input)));
            ApiParsers.split(parser, input, out var segments);
            return segments;
        }

        [Op]
        BufferSegments<AsciCode> test(N2 n)
        {
            const char Delimiter = '.';
            const byte SegCount = 6;
            var parser = ApiParsers.splitter(AsciCode.Dot);
            var input = edit(Case2Input);
            ApiParsers.split(parser, input, out var segments);
            return segments;
        }

        static ReadOnlySpan<AsciCode> Case2Input
            => new AsciCode[]{C.d9,C.d0,C.Dot, C.d3,C.d3,C.Dot, C.d3,C.d9,C.d1,C.Dot, C.d3,C.d8,C.d5,C.Dot, C.d9};
    }
}