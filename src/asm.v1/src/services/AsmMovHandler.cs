//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [ApiHost]
    public ref struct AsmMovHandler
    {
        readonly Span<Arrow<Imm64,IceRegister>> Buffer;

        int Index;

        [MethodImpl(Inline)]
        public AsmMovHandler(int capacity)
        {
            Buffer = new Arrow<Imm64,IceRegister>[capacity];
            Index = 0;
        }

        [MethodImpl(Inline), Op]
        public void Handle(in IceInstruction i)
        {
            if(i.Mnemonic == IceMnemonic.Mov && i.Op1Kind == IceOpKind.Immediate64 && i.Op0Kind == IceOpKind.Register)
                Handle(i.Immediate64, i.Op0Register);
        }

        public ReadOnlySpan<Arrow<Imm64,IceRegister>> Collected
        {
            [MethodImpl(Inline)]
            get => slice(Buffer,0, Index);
        }

        public int CollectionCount
        {
            [MethodImpl(Inline)]
            get => Index;
        }

        [MethodImpl(Inline), Op]
        public ref Arrow<Imm64,IceRegister> Entry(int index)
            => ref seek(Buffer, index);

        bool HasCapacity
        {
            [MethodImpl(Inline)]
            get => Index < Buffer.Length;
        }

        [MethodImpl(Inline), Op]
        void Handle(Imm64 src, IceRegister dst)
        {
            if(HasCapacity)
                Entry(Index++) = (src, dst);
        }
    }
}