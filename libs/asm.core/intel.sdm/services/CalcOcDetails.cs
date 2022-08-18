//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static SdmModels;

    partial class IntelSdm
    {
        public Index<SdmOpCodeDetail> CalcOcDetails()
            => CalcOcDetails(SdmPaths.Sources("sdm.instructions").Files(FS.Csv).ToReadOnlySpan());

        static Index<SdmOpCodeDetail> deduplicate(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var outgoing = span<SdmOpCodeDetail>(count);
            var j = 0u;
            var logicalKeys = hashset<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var logicalKey = input.AsmSig.Format() + input.OpCodeExpr.Format();
                if(logicalKeys.Contains(logicalKey))
                    continue;
                else
                    logicalKeys.Add(logicalKey);

                seek(outgoing, j) = input;
                seek(outgoing, j).OpCodeKey = j;
                j++;

            }
            return slice(outgoing, 0, j).ToArray();
        }

        Index<SdmOpCodeDetail> CalcOcDetails(ReadOnlySpan<FS.FilePath> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var kinds = Symbols.index<SdmTableKind>();
            Index<SdmOpCodeDetail> storage = alloc<SdmOpCodeDetail>(4000);
            var buffer = storage.Edit;
            var counter = 0u;
            var tables = list<Table>();
            for(var i=0; i<count; i++)
            {
                ref readonly var inpath = ref skip(src,i);
                var csv = LoadCsvTables(inpath);
                var id = inpath.FileName.WithoutExtension.Format();
                for(var j=0; j<csv.Length; j++)
                {
                    ref readonly var table = ref skip(csv,j);
                    var kind = (SdmTableKind)table.Kind;
                    ref readonly var symbol = ref kinds[kind];
                    if(kind == SdmTableKind.OpCodes)
                        counter += Convert(table, slice(buffer, counter));
                }
            }

            return deduplicate(slice(buffer,0,counter).ToArray().Sort());
        }

        string NormalizeSig(string src)
        {
            var i = text.index(src,Chars.Space);
            if(i > 0)
            {
                var mnemonic = text.left(src,i);
                var ops = CalcOperands(src);
                if(nonempty(ops))
                    return string.Format("{0} {1}", mnemonic, ops);
                else
                    return mnemonic;
            }
            else
                return src;
        }

        [Op]
        uint Convert(Table src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var rows = src.Rows;
            var count = rows.Length;
            var cols = src.Cols;
            var ocfixups = OcFixupRules;
            var sigfixups = SigFixupRules;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(rows,i);
                var target = new SdmOpCodeDetail();
                var cells = input.Cells;
                var valid = true;

                for(var k=0; k<cells.Length; k++)
                {
                    ref readonly var col = ref skip(cols,k);
                    ref readonly var cell = ref skip(cells,k);
                    var content = cell.Content?.ToString().Trim().Remove("*");
                    var name = text.trim(col.Name);
                    if(empty(content))
                        continue;

                    if(empty(name))
                    {
                        Warn($"Unnamed column with content '{content}'");
                        continue;
                    }
                    switch(name)
                    {
                        case "Opcode":
                        var octext = text.despace(text.trim(ocfixups.Apply(content)));
                        var oc = SdmOpCode.Empty;
                        target.OpCodeExpr = octext;
                        if(empty(octext))
                            valid = false;
                        else
                        {
                            SdmOpCodes.parse(octext, out oc).Require();
                            target.OpCodeValue = oc.OcValue();
                        }
                        break;

                        case "Instruction":
                            var monic = text.trim(text.ifempty(text.left(content, Chars.Space), content));
                            if(empty(monic))
                            {
                                valid = false;
                                break;
                            }

                            var sig = FixupSig(content);
                            target.AsmSig = NormalizeSig(sig);
                            target.Mnemonic = monic;
                            valid = true;
                        break;

                        case "Op En":
                        case "Op/ En":
                        case "Op / En":
                        case "Op/En":
                        case "Op /En":
                            target.EncXRef = content;
                            valid = true;
                        break;

                        case "Compat/Leg Mode":
                            target.Mode32 = content;
                            if(content == "N.E." || content == "NA")
                                target.Mode32 = "Invalid";
                            valid = true;
                        break;

                        case "64-Bit Mode":
                        case "64-bit Mode":
                            target.Mode64 = content.Replace("V/N.E.", "Valid");
                            if(content == "N.E." || content == "N.S." | content == "Inv.")
                                target.Mode64 = "Invalid";
                            valid = true;
                        break;

                        case "64/32-bit Mode":
                        case "64/32 -bit Mode":
                        case "64/32 bit Mode Support":
                            target.Mode64x32 = content;
                            if(text.trim(text.left(content, Chars.FSlash)) == "V")
                                target.Mode64 = "Valid";
                            if(content == "V/V")
                            {
                                target.Mode32 = "Valid";
                            }
                            else if(content == "V/NE" || content == "V/N.E." || content == "V/I")
                            {
                                target.Mode32 = "Invalid";
                            }

                            valid = true;
                        break;

                        case "CPUID":
                        case "CPUID Feature Flag":
                            target.CpuIdExpr = content;
                            valid = true;
                        break;

                        case "Description":
                            target.Description = text.replace(content, " .", ".");
                            valid = true;
                        break;
                        case "Operand1":
                        case "Operand 1":
                        case "Operand2":
                        case "Operand 2":
                        case "Operand3":
                        case "Operand 3":
                        case "Operand4":
                        case "Operand 4":
                            valid = false;
                            break;

                        default:
                            valid = false;
                            Warn(string.Format("Column {0} unrecognized", col.Name));
                            break;
                    }
                }

                if(valid)
                {
                    //AsmOpCodes.parse(target.OpCodeText, out var oc).Require();
                    //target.OpCodeValue = oc.OcValue();
                    seek(dst, counter++) = target;
                }
            }
            return counter;

            string FixupOpCode(string src)
                => text.despace(ocfixups.Apply(text.trim(src)));

            string FixupSig(string src)
                => text.despace(sigfixups.Apply(text.trim(src)));
        }
    }
}