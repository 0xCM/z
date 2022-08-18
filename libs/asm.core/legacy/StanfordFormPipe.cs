//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Msg;
    using static Chars;

    public class StanfordFormPipe : AppService<StanfordFormPipe>
    {
        public StanfordFormPipe()
        {

        }

        public Index<StanfordFormInfo> LoadFormInfo(in TextGrid src)
        {
            var rows = src.Rows;
            var count = rows.Length;
            var dst = alloc<StanfordFormInfo>(count);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    continue;

                row(skip(rows,i), ref seek(dst,i));
            }
            return dst;
        }

        public ReadOnlySpan<StanfordFormInfo> LoadFormInfo(FS.FilePath src)
        {
            var dst = list<StanfordFormInfo>();
            if(src.Exists)
            {
                var flow = Running($"Loading form records from {src.ToUri()}");
                var doc = TextGrids.parse(src);
                if(doc.Failed)
                {
                    Error(doc.Reason);
                    return array<StanfordFormInfo>();
                }

                var forms = LoadFormInfo(doc.Value);
                Ran(flow, LoadedForms.Format(forms.Length, src));
                return forms;
            }
            else
            {
                Error($"The file <{src.ToUri()}> does not exist");
                return array<StanfordFormInfo>();
            }
        }

        [Parser]
        static Outcome forminfo(string src, out AsmFormInfo dst)
        {
            dst = AsmFormInfo.Empty;
            var result = Outcome.Success;

            result = Fenced.unfence(src, SigFence, out var sigexpr);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,SigFence));

            result = AsmSigInfo.parse(sigexpr, out var _sig);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format("Sig", sigexpr));

            result = Fenced.unfence(src, OpCodeFence, out var opcode);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,OpCodeFence));

            dst = new AsmFormInfo(opcode, _sig);
            return true;
        }

        static ref StanfordFormInfo row(in TextRow src, ref StanfordFormInfo dst)
        {
            var i = 0;
            DataParser.parse(src[i++], out dst.Seq);
            dst.OpCode = src[i++];
            AsmSigInfo.parse(src[i++], out dst.Sig);
            forminfo(src[i++], out dst.FormExpr);
            return ref dst;
        }

        static Fence<char> SigFence => (LParen, RParen);

        static Fence<char> OpCodeFence => (Lt, Gt);

        //const string Implication = " => ";
    }
}