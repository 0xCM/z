//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ApiMemberCode : IDisposable
    {
        public static ApiMemberCode own(EncodingData data)
            => new (data);

        EncodingData Data;

        ApiMemberCode(EncodingData data)
        {
            Data = data;
        }

        void IDisposable.Dispose()
        {
            Data.Dispose();
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(uint i)
        {
            var offset = Data.Offsets[i];
            var size =  Data.Members[i].CodeSize;
            return slice(Data.CodeBuffer.Cells, offset, size);
        }

        public ByteSize CodeSize
        {
            [MethodImpl(Inline), Op]
            get => Data.CodeBuffer.Size;
        }

        [MethodImpl(Inline), Op]
        public unsafe MemorySegment Segment(uint i)
            => new (Data.CodeBuffer.BaseAddress + Data.Offsets[i], Data.Members[i].CodeSize);

        [MethodImpl(Inline), Op]
        public unsafe MemorySegment Segment(int i)
            => Segment((uint)i);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(int i)
            => Code((uint)i);

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(uint i)
            => ref Data.Tokens[i];

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(int i)
            => ref Data.Tokens[i];

        public ReadOnlySpan<ApiToken> Tokens
        {
            [MethodImpl(Inline)]
            get => Data.Tokens;
        }

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMember Member(uint i)
            => ref Data.Members[i];

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMember Member(int i)
            => ref Data.Members[i];

        [MethodImpl(Inline), Op]
        public MemberEncoding Encoding(int i)
            => new (Token(i), Data.Members[i].CodeSize);

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Data.Tokens.Count;
        }

        public sealed class EncodingData : IDisposable
        {
            public ICompositeDispenser Symbols;

            public IAllocation<byte> CodeBuffer;

            public Index<EncodedMember> Members;

            public Index<uint> Offsets;

            public Index<ApiToken> Tokens;

            public void Dispose()
            {
                Symbols.Dispose();
                CodeBuffer.Dispose();
            }
        }
    }
}