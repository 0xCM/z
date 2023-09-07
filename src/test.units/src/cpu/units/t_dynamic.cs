//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_dynamic : t_inx<t_dynamic>
    {
        public void check_blocks()
        {
            // var methods = typeof(Blocked).DeclaredMethods().Tagged<OpAttribute>().WithName("add");
            // foreach(var method in methods)
            // {
            //     foreach(var t in method.ParameterTypes())
            //     {
            //         Claim.yea(t.IsSpanBlock(), $"The parameter {t.Name} from the method {method.Name} is not of blocked type");
            //         var width = ApiIdentity.width(t);
            //         Claim.yea(width == TypeWidth.W128 || width == TypeWidth.W256, $"{width}");
            //     }
            // }
        }

        public void vbsll_imm_handle()
        {   const byte imm8 = 9;
            var name = nameof(gcpu.vbsll);
            var src = typeof(gcpu).DeclaredMethods().WithName(name).OfKind(VK.v128).Single();
            var op = Dynop.EmbedVUnaryOpImm(VK.vk128<uint>(), ApiIdentity.identify(src), src, imm8);
            var handle = CilDynamic.handle(op.Target);
            var dst = CilDynamic.method(handle);
            Claim.eq(dst.Name, name);
        }

        public unsafe void vbsll_128x32u()
        {
            const byte imm8 = 9;
            var host = typeof(gcpu);
            var w = w128;

            var resolver = VImm8UnaryResolvers.create<uint>(host, w);
            var vbsll = resolver.inject(imm8, ApiClassKind.Bsll).Operation;

            for(var i=0; i<RepCount; i++)
            {
                var x = Random.CpuVector<uint>(w128);
                var y = vbsll(x);
                var z = gcpu.vbsll(x,imm8);
                Claim.veq(z,y);
            }
        }
    }
}