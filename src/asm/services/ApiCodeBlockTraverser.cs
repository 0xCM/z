//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public class ApiCodeBlockTraverser : AppService<ApiCodeBlockTraverser>
    {
        AsmDecoder Decoder;


        // [Op]
        // public void Traverse(ApiBlockIndex src, IReceiver<ApiCodeBlock,AsmInstructionBlock> dst)
        // {
        //     var addresses = src.Addresses.View;
        //     var count = addresses.Length;
        //     for(var i=0u; i<count; i++)
        //         Traverse(src[skip(addresses,i)], dst);
        // }

        // [Op]
        // public void Traverse(Index<ApiCodeBlock> src, IReceiver<ApiCodeBlock,AsmInstructionBlock> dst)
        // {
        //     var blocks = src.View;
        //     var count = blocks.Length;
        //     for(var i=0u; i<count; i++)
        //         Traverse(skip(blocks,i), dst);
        // }

        // [Op]
        // public void Traverse(ReadOnlySpan<ApiCodeBlock> src, AsmReceiverModel dst)
        // {
        //     var blocks = src;
        //     var count = blocks.Length;
        //     for(var i=0u; i<count; i++)
        //         Traverse(skip(blocks,i), dst);
        // }

        // [Op]
        // public void Traverse(ReadOnlySpan<ApiCodeBlock> src, IReceiver<ApiCodeBlock> dst)
        // {
        //     var blocks = src;
        //     var count = blocks.Length;
        //     for(var i=0u; i<count; i++)
        //         dst.Deposit(skip(blocks,i));
        // }

        // [Op]
        // void Traverse(in ApiCodeBlock src, IReceiver<ApiCodeBlock,AsmInstructionBlock> dst)
        // {
        //     var outcome = Decoder.Decode(src, out var block);
        //     if(outcome)
        //         dst.Deposit(src, block);
        //     else
        //         Wf.Error(outcome.Message);
        // }
    }
}