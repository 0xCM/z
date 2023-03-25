//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    partial class ApiCode
    {
        [Op]
        public static MemoryAddress stub(MemoryAddress src, out AsmHexCode stub)
        {
            const byte StubSize = JmpRel32.InstSize;
            stub = AsmHexCode.Empty;
            var target = src;
            var buffer = sys.bytes(Cells.alloc(w64));
            ref var data = ref src.Ref<byte>();
            ByteReader.read6(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = AsmHexApi.asmhex(slice(buffer, 0, StubSize));
                Rip rip = (src, StubSize);
                target = AsmRel.target(rip, stub.Bytes);
            }
            return target;
        }
    }    
}