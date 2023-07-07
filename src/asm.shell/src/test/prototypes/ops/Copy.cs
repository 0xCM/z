//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "vcopy128")]
        public ref struct VCopy128
        {
            SpanBlock128<byte> Source;

            SpanBlock128<byte> Target;

            [Op]
            public void copy5x128()
            {
                var v0 = vblocks.vload(Source,0);
                var v1 = vblocks.vload(Source,1);
                var v2 = vblocks.vload(Source,2);
                var v3 = vblocks.vload(Source,3);
                var v4 = vblocks.vload(Source,4);

                cpu.vstore(v0, ref Target.BlockLead(0));
                cpu.vstore(v1, ref Target.BlockLead(1));
                cpu.vstore(v2, ref Target.BlockLead(2));
                cpu.vstore(v3, ref Target.BlockLead(3));
                cpu.vstore(v4, ref Target.BlockLead(4));
            }

            [Op]
            public static void copy(SpanBlock128<byte> src, SpanBlock128<byte> dst)
            {
                var count = src.BlockCount;
                for(var i=0; i<count; i++)
                    cpu.vstore(vblocks.vload(src,i), ref dst.BlockLead(i));
            }

        }

        [ApiHost(prototypes + "vcopy256")]
        public ref struct VCopy256
        {
            SpanBlock256<byte> Source;

            SpanBlock256<byte> Target;

            [Op]
            public void copy5x256()
            {
                cpu.vstore(vblocks.vload(Source,0), ref Target.BlockLead(0));
                cpu.vstore(vblocks.vload(Source,1), ref Target.BlockLead(1));
                cpu.vstore(vblocks.vload(Source,2), ref Target.BlockLead(2));
                cpu.vstore(vblocks.vload(Source,3), ref Target.BlockLead(3));
                cpu.vstore(vblocks.vload(Source,4), ref Target.BlockLead(4));
            }

            [Op]
            public static void copy(SpanBlock256<byte> src, SpanBlock256<byte> dst)
            {
                var count = src.BlockCount;
                for(var i=0; i<count; i++)
                    cpu.vstore(vblocks.vload(src,i), ref dst.BlockLead(i));
            }
        }
    }
}