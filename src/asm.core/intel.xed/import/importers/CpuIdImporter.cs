//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedImport
    {
        public class CpuIdImporter
        {
            public static CpuIdImporter.Output calc()
            {
                var parser = new CpuIdImporter();
                parser.Run(XedPaths.Service.CpuIdSource().ReadLines().Where(text.nonempty));
                return parser.Parsed;
            }

            ConcurrentBag<string> IsaBuffer = new();

            ConcurrentBag<CpuIdImport> CpuIdBuffer = new();

            Index<CpuIdImport> CpuIdFinal = sys.empty<CpuIdImport>();

            Index<IsaImport> IsaFinal = sys.empty<IsaImport>();

            public Output Parsed => new Output(this);

            void SealIsaImports()
            {
                var sorted = IsaBuffer.ToHashSet().Map(x => x).Where(text.nonempty).Sort().Index();
                var count = sorted.Count;
                IsaFinal = alloc<IsaImport>(count);
                for(var i=z8; i<count; i++)
                {
                    ref readonly var src = ref sorted[i];
                    ref var dst = ref IsaFinal[i];
                    dst.Seq = i;
                    dst.XedName = src;
                    dst.IsaName = IsaName(src);
                }
            }

            void SealCpuIdImports()
                => CpuIdFinal = CpuIdBuffer.Index().Sort().Resequence();

            public void Run(Index<string> data, bool pll= true)
            {
                iter(data.Select(normalize), Parse, pll);
                exec(pll,
                    SealIsaImports,
                    SealCpuIdImports
                );
            }

            uint CpuIdSeq;

            [MethodImpl(Inline)]
            CpuIdImport CpuIdRecord(asci64 spec, asci32 isa)
                => new CpuIdImport((ushort)inc(ref CpuIdSeq), spec, isa);

            void Parse(string src)
            {
                const string Null = "n/a";
                var input = Require.notnull(src);
                if(!IsComment(input))
                {
                    if(split(input, out var isa, out var cpuid))
                    {
                        IsaBuffer.Add(isa);
                        if(nonempty(cpuid))
                        {
                            var parts = text.split(isa, Chars.Space).Where(x => x != Null).ToIndex();
                            for(var i=0u; i<parts.Count; i++)
                                CpuIdBuffer.Add(CpuIdRecord(parts[i], IsaName(isa)));
                        }
                    }
                }
            }

            [MethodImpl(Inline)]
            static string IsaName(string src)
                => text.remove(src,"XED_ISA_SET_");

            static bool split(string src, out string isa, out string cpuid)
            {
                var result = true;
                var j = text.index(src,Chars.Colon);
                if(j > 0)
                {
                    isa = text.left(src,j);
                    cpuid = text.trim(text.right(src,j));
                }
                else
                {
                    isa = EmptyString;
                    cpuid = EmptyString;
                    result = false;
                }
                return result;
            }

            static bool IsComment(string src)
                => text.begins(src, Chars.Hash);

            static string normalize(string src)
            {
                var input = text.trim(text.despace(Require.notnull(src)));
                var output = input;
                if(IsComment(input))
                    return output;
                var i = text.index(input, Chars.Hash);
                if(i > 0)
                    output = text.trim(text.left(input,i));
                return output;
            }

            public readonly struct Output
            {
                readonly CpuIdImporter Parser;

                [MethodImpl(Inline)]
                internal Output(CpuIdImporter parser)
                {
                    Parser = parser;
                }

                public ref readonly Index<CpuIdImport> CpuIdRecords
                    => ref Parser.CpuIdFinal;

                public ref readonly Index<IsaImport> IsaRecords
                    => ref Parser.IsaFinal;
            }
        }
    }
}