//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct V256Imm8UnaryResover<T> : IImm8UnaryResolver256<T>
        where T : unmanaged
    {
        public Type Host {get;}

        public V256Imm8UnaryResover(Type host)
        {
            Host = host;
        }

        OpIdentity id => default;

        public DynamicDelegate<UnaryOp<Vector256<T>>> @delegate(byte count)
            => Dynop.EmbedVUnaryOpImm<T>(VK.vk256<T>(), id, gApiMethod(VK.vk256<T>(), id.Name),count);

        MethodInfo gApiMethod(Vec256Type hk, string name)
            => Host.DeclaredMethods().WithName(name).OfKind(hk).Single();
    }
}