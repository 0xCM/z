//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class CsGenCmd : WfAppCmd<CsGenCmd>
    {
        SymGen SymGen => Channel.Channeled<SymGen>();

        SymbolFactories SymbolFactories => Channel.Channeled<SymbolFactories>();

        CsLang CsLang => Channel.Channeled<CsLang>();

        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = AsciLookups.emit(8u, name,content, dst);
            Channel.Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/cs/keywords")]
        void GenCsKeywords()
        {
            var src = AppDb.AppData().Path("ms.cs.keywords", FileKind.List);
            const string FieldName = "CsKeywordList";
            if(!src.Exists)
            {
                Error(FS.missing(src));
            }
            else
            {
                var list = ItemLists.constants(FieldName, src.ReadLines(skipBlank:true).Storage);
                var dst = text.buffer();
                dst.Append("public static string[] ");
                SymGen.EmitArrayInitializer(list,dst);
                Channel.Write(dst.Emit());
            }
        }

        [CmdOp("gen/switchmaps")]
        Outcome GenSwitchMap(CmdArgs args)
        {
            GenIntSwitch();
            GenEnumToIntSwitch();
            return true;
        }

        void GenIntSwitch()
        {
            var src = array<uint>(34, 51, 98, 101, 264, 888, 911, 902, 3828, 13, 19);
            var dst = array<uint>(3000, 201, 197, 313145, 264801, 911122, 4, 7, 11, 54, 99);
            var spec = CsModels.@switch("test", src, dst);
            var emitter = text.emitter();
            SymGen.render(spec,emitter);
            Channel.Write(emitter.Emit());
            //Channel.Write(result);
        }

        void GenEnumToIntSwitch()
        {
            var src = array<Hex3Kind>(Hex3Kind.x02, Hex3Kind.x03, Hex3Kind.x04);
            var dst = array<byte>(2,3,4);
            var spec = CsModels.@switch("enum_test", src, dst);
            var emitter = text.emitter();
            SymGen.render(spec,emitter);
            Channel.Write(emitter.Emit());
        }

        [CmdOp("gen/hex/strings")]
        Outcome GenHexStrings(CmdArgs args)
        {
            var name = "HexStringArrays";
            var ns = "Z0";
            var dst = CsGen.emitter();
            var offset = 0u;
            dst.Namespace(offset, ns);
            dst.OpenStruct(offset, name);
            offset +=4;

            var content = HexGen.array("Hex8Strings", byte.MinValue, byte.MaxValue, LetterCaseKind.Upper);
            dst.IndentLine(offset,content);
            offset -= 4;
            dst.CloseStruct(offset);
            offset -= 4;

            Channel.FileEmit(dst.Emit(), AppDb.CgStage().Path(name,FileKind.Cs));

            return true;
        }

        [CmdOp("gen/bytes")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            RenderByteSpans(offset,dst);
            Channel.FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
            return true;
        }

        public static void RenderByteSpans(uint offset, ITextEmitter dst)
        {
            Bytes.bytespan<byte>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0,255,offset,dst);
            Bytes.bytespan<uint>(0,255,offset,dst);
            Bytes.bytespan<ulong>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0, 511, offset, dst);
            Bytes.bytespan<ushort>(0, Pow2.T11m1, offset, dst);
        }

        
        [CmdOp("gen/strings/ints")]
        Outcome GenIntStrings(CmdArgs args)
        {
            var result = Outcome.Success;
            result = DataParser.parse(arg(args,0).Value, out uint min);
            result = DataParser.parse(arg(args,1).Value, out uint max);
            var values = list<string>();
            var name = string.Format("Range{0}To{1}", min, max);
            var n = max.ToString().Length;
            for(var i=min; i<=max; i++)
                values.Add(i.ToString().PadLeft(n));

            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            CsLang.StringLits().Emit(name,values.ViewDeposited(), dst);
            return result;
        }


        [CmdOp("gen/symspan")]
        void GenSymSpan()
            => SymGen.EmitSymSpan<AsciLetterLoSym>(AppDb.CgStage().Path("symspan", FileKind.Cs));

        [CmdOp("gen/enum/cs/keywords")]
        Outcome CsKeywords(CmdArgs args)
        {
            var src = AppDb.CgStage().Path("ms","ms.cs.keywords", FileKind.List);
            if(!src.Exists)
            {
                Channel.Error(FS.missing(src));
            }
            else
            {
                var items = new ItemList<Constant<string>>("CsKeywordList", mapi(src.ReadLines(), (i,line) => new ListItem<Constant<string>>((uint)i,text.trim(line))));
                var dst = text.buffer();
                SymGen.EmitArrayInitializer(items,dst);
                Channel.Write(dst.Emit());

            }
            return true;
        }
    }
}