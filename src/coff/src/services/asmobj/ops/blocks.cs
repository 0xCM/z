//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System.Linq;

    using static core;

    partial class AsmObjects
    {
        public static AsmCodeBlocks blocks(ProjectContext context, in FileRef file, ref uint seq, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var blocks = src.GroupBy(x => x.BlockAddress).Array();
            var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
            var composite = dispenser.Composite();
            for(var i=0; i<blocks.Length; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var blockcode = block.Array();
                var blockname = first(blockcode).BlockName.Format();
                var blockaddress = block.Key;
                var codebuffer = alloc<AsmCode>(blockcode.Length);
                for(var k=0; k<blockcode.Length; k++)
                {
                    ref readonly var row = ref skip(blockcode,k);
                    var encoding = new AsmEncodingInfo();
                    encoding.Seq = seq++;
                    encoding.DocSeq = row.DocSeq;
                    encoding.EncodingId = row.EncodingId;
                    encoding.OriginId = row.OriginId;
                    encoding.InstructionId = row.InstructionId;
                    encoding.IP = row.IP;
                    encoding.Encoded = row.Encoded.Bytes;
                    encoding.Size = row.Size;
                    encoding.Asm = row.Asm.Content;
                    seek(codebuffer,k) = code(composite,encoding);
                }
                seek(blockbuffer,i) = new AsmCodeBlock(composite.Symbol(blockaddress,blockname), codebuffer);
            }
            var origin = context.Root(file);
            return new AsmCodeBlocks(composite.Label(origin.DocName), origin.DocId, blockbuffer);
        }

        static Index<AsmCodeBlocks> blocks(IProjectWorkspace project, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var collected = dict<uint, AsmCodeBlocks>();
            var groups = src.GroupBy(x => x.OriginId).Array();
            var buffer = alloc<AsmCodeBlocks>(groups.Length);
            var composite = dispenser.Composite();
            for(var i=0; i<groups.Length; i++)
            {
                ref readonly var group = ref skip(groups,i);
                var blocks = group.ToArray().GroupBy(x => x.BlockName).Array();
                if(blocks.Length == 0)
                    continue;

                var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);
                    var blockcode = block.Array();
                    if(blockcode.Length == 0)
                        continue;

                    var blockname = block.Key.Format();
                    var blockaddress = first(blockcode).BlockAddress;
                    var codebuffer = alloc<AsmCode>(blockcode.Length);
                    for(var k=0; k<blockcode.Length; k++)
                    {
                        ref readonly var row = ref skip(blockcode,k);
                        var encoding = new AsmEncodingInfo();
                        encoding.Seq = row.Seq;
                        encoding.DocSeq = row.DocSeq;
                        encoding.EncodingId = row.EncodingId;
                        encoding.OriginId = row.OriginId;
                        encoding.IP = row.IP;
                        encoding.Encoded = row.Encoded.Bytes;
                        encoding.InstructionId = row.InstructionId;
                        encoding.Size = row.Size;
                        encoding.Asm = row.Asm.Content;
                        seek(codebuffer,k) = code(composite,encoding);
                    }

                    seek(blockbuffer,j) = new AsmCodeBlock(composite.Symbol(blockaddress, blockname), codebuffer);
                }

                var origin = FileCatalog.load(project.ProjectFiles().Storage.ToSortedSpan()).Doc(group.Key);
                seek(buffer,i) = new AsmCodeBlocks(composite.Label(origin.DocName), origin.DocId, blockbuffer);
            }
            return buffer;
        }

        public static Index<ObjBlock> blocks(FilePath path)
        {
            var lines = path.ReadLines(true);
            var reader = lines.Storage.Reader();
            reader.Next();
            var buffer = alloc<ObjBlock>(lines.Length - 1);
            var i=0u;
            while(reader.Next(out var line))
            {
                var cells = text.split(line,Chars.Pipe);
                Require.equal(ObjBlock.FieldCount, cells.Length);
                ref var dst = ref seek(buffer,i++);
                var src = cells.Reader();
                DataParser.parse(src.Next(), out dst.Seq).Require();
                DataParser.parse(src.Next(), out dst.BlockNumber).Require();
                DataParser.parse(src.Next(), out dst.OriginId).Require();
                DataParser.parse(src.Next(), out dst.BlockName).Require();
                DataParser.parse(src.Next(), out dst.BlockAddress).Require();
                DataParser.parse(src.Next(), out dst.BlockSize).Require();
                DataParser.parse(src.Next(), out dst.Source).Require();
            }
            return buffer;
        }

        public static Index<ObjBlock> blocks(Index<ObjDumpRow> src)
        {
            src.Sort();
            var count = src.Count;
            var seq = 0u;
            var docid = 0u;
            var docname = EmptyString;
            var blockname = EmptyString;
            var @base = MemoryAddress.Zero;
            var dst = list<ObjBlock>();
            var size = 0u;
            var number = 0u;
            var source = _FileUri.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(i==0)
                {
                    docid = row.OriginId;
                    blockname = row.BlockName;
                    source = row.Source;
                    docname = row.Source.Path.FileName.Format();
                    @base = row.BlockAddress;
                }

                if(row.BlockName != blockname)
                {
                    var block = new ObjBlock();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockAddress = @base;
                    block.BlockName = blockname;
                    block.BlockNumber = number++;
                    block.BlockSize = size;
                    block.Source = source;
                    dst.Add(block);
                    size = 0;
                    source = row.Source;
                }

                if(row.OriginId != docid)
                    number = 0;

                docid = row.OriginId;
                blockname = row.BlockName;
                docname = row.Source.Path.FileName.Format();
                @base = row.BlockAddress;
                size += row.Size;

                if(i==count-1)
                {
                    var block = new ObjBlock();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockName = blockname;
                    block.BlockAddress = @base;
                    block.BlockNumber = number++;
                    block.Source = source;
                    block.BlockSize = size;
                    dst.Add(block);
                }
            }

            return dst.ToArray();
        }
    }
}