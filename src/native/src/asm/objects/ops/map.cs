//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Asm;
    partial class AsmObjects
    {
        static Index<AsmCodeMapEntry> map(IProjectWorkspace project, Index<ObjDumpRow> src, CompositeBuffers dispenser)
        {
            var distilled = blocks(project, src, dispenser);
            var entries = list<AsmCodeMapEntry>();
            for(var i=0; i<distilled.Count; i++)
            {
                ref readonly var blocks = ref distilled[i];
                if(blocks.Count == 0)
                    continue;

                var blocknumber = 0u;
                var @base = MemoryAddress.Zero;

                for(var j=0; j<blocks.Count; j++)
                {
                    ref readonly var block = ref blocks[j];
                    var count = block.Count;
                    ref readonly var address = ref block.Label.Location.Address;
                    ref readonly var name = ref block.Label.Name;
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var c = ref block[k];

                        if(j==0 && k==0)
                            @base = c.Encoded.BaseAddress;

                        var entry = new AsmCodeMapEntry();
                        entry.Seq = c.Seq;
                        entry.DocSeq = c.DocSeq;
                        entry.EncodingId = c.EncodingId;
                        entry.OriginId = blocks.OriginId;
                        entry.InstructionId = asm.instid(blocks.OriginId, c.IP, c.Encoding);
                        entry.OriginName = blocks.OriginName;
                        entry.BlockNumber = blocknumber;
                        entry.BlockName = name;
                        entry.BlockAddress = address;
                        entry.IP = c.IP;
                        entry.Size = c.EncodingSize;
                        entry.Encoded = c.Encoded;
                        entry.Asm = c.Asm;
                        entry.BlockSize = block.Size;
                        entries.Add(entry);
                    }

                    blocknumber++;
                }
            }

            return entries.ToArray().Sort();
        }
    }
}