//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        // public static void located(FilePath src)
        // {
        //     var data = span<byte>(src.Size);
        //     var offsets = list<Address32>();
        //     using var reader = src.AsciLineReader();
        //     var line = AsciLineCover.Empty;
        //     var offset = 0u;
        //     var rebased = Address32.Zero;
        //     var result = true;
        //     var @base = MemoryAddress.Zero;
        //     while(reader.Next(out line) && result)
        //     {                    
        //         var codes = line.Codes;
        //         var i = SQ.index(codes, Chars.Space);
        //         if(i > 0)
        //         {
        //             var left = SQ.left(codes,i);
        //             result = Hex.parse(left, out ulong address);
        //             if(!result)
        //                 sys.@throw(AppMsg.ParseFailure.Format("Location", left.Format()));

        //             if(@base == 0u)
        //                 @base = address;

        //             var right = SQ.right(codes,i);
        //             var size = Hex.parse(right, ref offset, data);
        //             if(size)
        //             {
        //                 offsets.Add(rebased);
        //                 rebased += size.Data;
        //             }
        //             else
        //                 sys.@throw(AppMsg.ParseFailure.Format("Hex", right.Format()));
        //         }

        //     }
        //     throw new NotImplementedException();
        //     //return new MemoryHeap(@base, src.Size, offsets.ToArray());
        // }
    }
}