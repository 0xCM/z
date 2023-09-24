//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static SdmModels;
class IntelSdmCmd : WfAppCmd<IntelSdmCmd>
{

    IntelSdm IntelSdm => Wf.IntelSdm();

    IDbArchive AsmDb => EnvDb.Scoped("asm.db");

    static IEnumerable<SdmOpCodeRow> OpCodeRows(ReadOnlySpan<string> src)
    {
        return default;
    }
    [CmdOp("sdm/instructions")]
    void LoadInstructions()
    {        
        var dst = bag<SdmOpCodeRow>();
        var files = IntelSdm.InstructionFiles();
        foreach(var file in files)
        {
            var lines = file.ReadLines();
            for(var i=0; i<lines.Count-2; i++)
            {
                if(lines[i].StartsWith( "## OpCodes") && lines[i+1].StartsWith("-----"))
                {
                    i+=2;
                    var header = text.trim(lines[i].Split(Chars.Pipe)).Mapi((i,x) => (i,x));
                    i++;
                    while(i++ < lines.Count)
                    {
                        if(empty(lines[i]))
                            break;
                        
                        var cells = text.trim(text.split(lines[i], Chars.Pipe)).ToSeq();
                        var row = new SdmOpCodeRow();
                        if(cells.Length >= 3)
                        {
                            row.OpCode = cells[0];
                            row.Instruction = cells[1];
                            row.Encoding = cells[2];
                            dst.Add(row);
                        }

                        if(cells.Length >= 4)
                        {
                            row.Mode64 = cells[3];
                        }

                        if(cells.Length >= 5)
                        {
                            row.Description = cells.Last;
                        }

                    }
                }
            }
        }
        Channel.TableEmit(dst.Array().Sort(), AsmDb.Path("sdm.opcodes", FileKind.Csv));
    }
}