//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public class LlvmCodeGen : WfSvc<LlvmCodeGen>
    {
        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        CsLang CsLang => Wf.CsLang();

        const string TargetNs = "Z0.llvm.strings";

        const string CgSrc = "cg.llvm/src";

        const byte Margin = 4;

        public void Run(bool staged, bool index = true)
        {
            EmitStringTables(staged, index);
            EmitAsmIds(staged, index);
        }

        static ItemList<string> reduce(ItemList<AsmIdentifier,ushort,asci32> src)
        {
            var dst = new ItemList<string>(src.Name, sys.alloc<ListItem<string>>(src.Count));
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var item = ref src[i];
                dst[i] = new ListItem<string>(item.Id, item.Name.Format());
            }
            return dst;
        }

        IDbArchive Staged()
            => AppDb.CgStage().Scoped(CgSrc);

        IDbArchive Live()
            => AppDb.CgRoot().Scoped(CgSrc);

        IDbArchive CgOut(bool staged)
            => staged ? Staged() : Live();

        public void EmitAsmIds(bool staged, bool index)
        {
            var src = reduce(DataProvider.AsmIdentifiers().ToItemList());
            var name = "AsmId";
            CsLang.EmitStringTable(TargetNs, ClrEnumKind.U16, src, CgOut(staged), index);
            var offset = 0u;
            var buffer = text.emitter();
            buffer.IndentLineFormat(offset, "namespace {0}", "Z0");
            buffer.IndentLine(offset, Chars.LBrace);
            offset+=Margin;
            CsRender.@enum(offset, name, @readonly(map(DataProvider.AsmIdentifiers().Entries,e => Literals.literal(e.Key, e.Value.Id))), buffer);
            offset-=Margin;
            buffer.IndentLine(offset, Chars.RBrace);
            var dst = CgOut(staged).Path(name,FileKind.Cs);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(buffer.Emit());
        }

        public void EmitStringTables(bool staged, bool index)
            => EmitStringTables(DataProvider.Lists().Where(x => x.Name != "vcodes"), staged, index);

        public void EmitStringTables(ReadOnlySpan<LlvmList> src, bool staged, bool index)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var flows = new DataList<Arrow<_FileUri>>();
            for(var i=0; i<count; i++)
                EmitStringTable(skip(src,i), staged, true);
        }

        StringTable EmitStringTable(LlvmList src, bool staged, bool index)
            => CsLang.EmitStringTable(TargetNs, ClrEnumKind.U32, src.ToItemList(), CgOut(staged), index);
   }
}