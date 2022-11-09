//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitChecks;

    using static CreditModel;
    using static CreditModel.Vendor;
    using static CreditModel.Volume;
    using static CreditModel.Chapter;
    using static CreditModel.Section;
    using static CreditModel.Topic;
    using static CreditModel.Appendix;
    using static CreditModel.ContentNumber;

    using CT = CreditModel.CreditContentType;

    [ApiHost]
    public class CheckCredits : Checker<CheckCredits>
    {
        [Op]
        public static bit encode()
        {
            var result = eq(CreditBits.vendor(Intel).Vendor, Intel);
            result &= eq(CreditBits.vendor(Amd).Vendor, Amd);
            result &= eq(CreditBits.volume(Vol1).Volume, Vol1);
            result &= eq(CreditBits.volume(Vol2A).Volume, Vol2A);
            result &= eq(CreditBits.volume(Vol2B).Volume, Vol2B);
            result &= eq(CreditBits.volume(Vol2C).Volume, Vol2C);
            result &= eq(CreditBits.chapter(Chapter3).Chapter, Chapter3);
            result &= eq(CreditBits.chapter(Chapter4).Chapter, Chapter4);
            result &= eq(CreditBits.chapter(Chapter14).Chapter, Chapter14);
            result &= eq(CreditBits.chapter(Chapter8).Chapter, Chapter8);
            result &= eq(CreditBits.appendix(AppendixA).Appendix, AppendixA);
            result &= eq(CreditBits.appendix(AppendixB).Appendix, AppendixB);
            result &= eq(CreditBits.appendix(AppendixD).Appendix, AppendixD);
            result &= eq(CreditBits.section(Section2).Section, Section2);
            result &= eq(CreditBits.section(Section3).Section, Section3);
            result &= eq(CreditBits.section(Section10).Section, Section10);
            result &= eq(CreditBits.topic(Topic4).Topic, Topic4);
            result &= eq(CreditBits.topic(Topic7).Topic, Topic7);
            result &= eq(CreditBits.topic(Topic7).Topic, Topic7);
            return result;
        }

        [Op]
        public static bit encode_refs()
        {
            var docref = CreditBits.credit(Intel, Vol2A, Chapter3, Section4, Topic5);
            var result = eq(docref.Vendor, Intel);
            result &= eq(docref.Volume, Vol2A);
            result &= eq(docref.Chapter, Chapter3);
            result &= eq(docref.Section, Section4);
            result &= eq(docref.Topic, Topic5);
            return result;
        }

        [Op]
        public static bit encode_table_refs()
        {
            var tr = CreditBits.table(d2, d3, d1);
            var result = eq(tr.Level0, d2);
            result &= eq(tr.Level1, d3);
            result &= eq(tr.Level2, d1);
            result &= eq(tr.ContentType, CreditModel.CreditContentType.Table);
            return result;
        }

        protected override void Execute(IEventTarget log)
        {
            var flow = Running();
            try
            {
                Exec(CheckCreditFields);
                Exec(CheckReferenceFields);
                Exec(CheckContentFields);
                Exec(CheckTableFields);
                var result = CheckLiterals();
            }
            catch(Exception e)
            {
                Error(e);
            }

            Ran(flow);
        }

        void Exec<R>(Func<R> f)
            => Status($"{f()}");

        [Op]
        ulong CheckCreditFields()
        {
            var result = 0ul;
            var index = z8;
            result |= biteq(CreditBits.vendor(Intel).Vendor, Intel, index++);
            result |= biteq(CreditBits.vendor(Amd).Vendor, Amd, index++);
            result |= biteq(CreditBits.volume(Vol1).Volume, Vol1, index++);
            result |= biteq(CreditBits.volume(Vol2A).Volume, Vol2A, index++);
            result |= biteq(CreditBits.volume(Vol2B).Volume, Vol2B, index++);
            result |= biteq(CreditBits.volume(Vol2C).Volume, Vol2C, index++);
            result |= biteq(CreditBits.chapter(Chapter3).Chapter, Chapter3, index++);
            result |= biteq(CreditBits.chapter(Chapter4).Chapter, Chapter4, index++);
            result |= biteq(CreditBits.chapter(Chapter14).Chapter, Chapter14, index++);
            result |= biteq(CreditBits.chapter(Chapter8).Chapter, Chapter8, index++);
            result |= biteq(CreditBits.appendix(AppendixA).Appendix, AppendixA, index++);
            result |= biteq(CreditBits.appendix(AppendixB).Appendix, AppendixB, index++);
            result |= biteq(CreditBits.appendix(AppendixD).Appendix, AppendixD, index++);
            result |= biteq(CreditBits.section(Section2).Section, Section2, index++);
            result |= biteq(CreditBits.section(Section3).Section, Section3, index++);
            result |= biteq(CreditBits.section(Section10).Section, Section10, index++);
            result |= biteq(CreditBits.topic(Topic4).Topic, Topic4, index++);
            result |= biteq(CreditBits.topic(Topic7).Topic, Topic7, index++);
            result |= biteq(CreditBits.topic(Topic7).Topic, Topic7, index++);
            return result;
        }

        [Op]
        ulong CheckReferenceFields()
        {
            var result = 0ul;
            var index = z8;
            var r1 = CreditBits.credit(Intel, Vol2A, Chapter3, Section4, Topic5);
            result |= biteq(r1.Vendor, Intel, index++);
            result |= biteq(r1.Volume, Vol2A, index++);
            result |= biteq(r1.Chapter, Chapter3, index++);
            result |= biteq(r1.Section, Section4, index++);
            result |= biteq(r1.Topic, Topic5, index++);
            return result;
        }

        [Op]
        ulong CheckContentFields()
        {
            var result = 0ul;
            var index = z8;
            var tr = CreditBits.table(d2, d3, d1);
            var r1 = CreditBits.credit(Intel, Vol2A, Chapter3, Section4, Topic5, tr);
            result |= biteq(r1.Vendor, Intel, index++);
            result |= biteq(r1.Volume, Vol2A, index++);
            result |= biteq(r1.Chapter, Chapter3, index++);
            result |= biteq(r1.Section, Section4, index++);
            result |= biteq(r1.Topic, Topic5, index++);
            return result;
        }

        [Op]
        ulong CheckTableFields()
        {
            var result = 0ul;
            var index = z8;
            var tr = CreditBits.table(d2, d3, d1);
            result |= biteq(tr.Level0, d2, index++);
            result |= biteq(tr.Level1, d3, index++);
            result |= biteq(tr.Level2, d1, index++);
            result |= biteq(tr.ContentType, CT.Table, index++);
            return result;
        }

        ReadOnlySpan<bit> CheckLiterals()
        {
            var index = z8;
            var src = TaggedLiterals.binary<DocField,ulong>().ToReadOnlySpan();
            var count = src.Length;
            var dst = span<bit>(count);
            Check(src,dst);
            return dst;
        }

        [Op]
        void Check(ReadOnlySpan<BinaryLiteral<ulong>> src, Span<bit> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var literal = ref skip(src,i);
                var data = literal.Data;
                var text = literal.Text;
                var bits = BitSpans32.load(bitparse(text));
                var bitval = bits.Convert<ulong>();
                seek(dst,i) = gmath.eq(bitval, data);
            }
        }

        public static bit t_docref_bitfield()
        {
            var result = bit.On;
            var tField = typeof(DocField);
            var literals = TaggedLiterals.binary<DocField,ulong>();
            for(var i=0; i<literals.Length; i++)
            {
                var literal = literals[i];
                var bits = BitSpans32.load(bitparse(literal.Text));
                var bitval = bits.Convert<ulong>();
                result &= gmath.eq(bitval, literal.Data);
            }
            return result;
        }

        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static Span<bit> bitparse(string src)
        {
            var data = span(src.RemoveAny(Chars.LBracket, Chars.RBracket, Chars.Space, Chars.Underscore, (char)AsciLetterSym.b));
            var len = data.Length;
            var lastix = len - 1;
            var dst = new bit[len];
            BitParser.parse(data, dst);
            return dst;
        }
    }
}