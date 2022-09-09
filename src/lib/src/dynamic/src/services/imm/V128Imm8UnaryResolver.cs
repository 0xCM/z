//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct V128Imm8UnaryResolver<T> : IImm8UnaryResolver128<T>
        where T : unmanaged
    {
        OpIdentity id => default;

        public Type Host {get;}

        public V128Imm8UnaryResolver(Type host)
        {
            Host = host;
        }

        public DynamicDelegate<UnaryOp<Vector128<T>>> @delegate(byte count)
            => Dynop.EmbedVUnaryOpImm<T>(VK.vk128<T>(), id, gApiMethod(VK.vk128<T>(), id.Name),count);

        public DynamicDelegate<UnaryOp<Vector128<T>>> @delegate(byte count, OpIdentity id)
            => Dynop.EmbedVUnaryOpImm<T>(VK.vk128<T>(), id, gApiMethod(VK.vk128<T>(), id.Name),count);

        static string name(ApiClassKind k)
            => $"v{k.Format()}";

        public DynamicDelegate<UnaryOp<Vector128<T>>> inject(byte imm8, ApiClassKind kind)
            => Dynop.EmbedVUnaryOpImm<T>(VK.vk128<T>(),
                ApiIdentityBuilder.build(name(kind), NativeTypeWidth.W128, typeof(T).NumericKind(), true), gApiMethod(VK.vk128<T>(), name(kind)),imm8);

        MethodInfo gApiMethod(Vec128Type hk, string name)
            => Host.DeclaredMethods().WithName(name).OfKind(hk).Single();
    }
}