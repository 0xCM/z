//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using EC = EcmaConstants;
    using SK = EcmaStreamKind;

    public unsafe struct MetadataMemory
    {
        readonly MemorySeg Source;
        
        readonly uint LastPosition;

        uint Position;

        public readonly AssemblyKey AssemblyKey;

        [MethodImpl(Inline)]
        public MetadataMemory(MemorySeg src, AssemblyKey assembly)
        {
            Source = src;
            Position = 0;
            LastPosition = src.Size;
            AssemblyKey = assembly;
        }

        [MethodImpl(Inline)]
        uint Remaining()
            => Position <= LastPosition ? LastPosition - Position : 0;

        [MethodImpl(Inline)]
        void Advance(ByteSize size)
        {
            Position += size;
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<byte> Bytes()
            => Source.View;

        [MethodImpl(Inline)]
        ReadOnlySpan<byte> Bytes(uint offset)
            => slice(Source.View, offset);

        [MethodImpl(Inline)]
        T* Pointer<T>()
            where T : unmanaged
                => (Source.BaseAddress + Position).Pointer<T>();

        [MethodImpl(Inline)]
        T Read<T>()
            where T : unmanaged
        {
            var value = *Pointer<T>();
            Advance(size<T>());
            return value;
        }

        ReadOnlySpan<byte> Read(uint requested)
        {
            var length = Position + requested < LastPosition ? requested : Remaining();
            var data = slice(Bytes(),Position, length);
            Advance(length);
            return data;
        }

        [MethodImpl(Inline)]
        byte Read()
            => Read<byte>();

        int Find(byte value)
        {
            var src = Bytes(Position);
            var pos = -1;
            for(var i=0; i<src.Length; i++)
            {
                if(skip(src,i) == value)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        static EcmaStreamKind StreamKind(string src)
            => src switch {
                EC.StringStreamName => SK.String,
                EC.BlobStreamName => SK.Blob,
                EC.UserStringStreamName => SK.UserString,
                EC.CompressedMetadataTableStreamName => SK.CompressedTable,
                EC.UncompressedMetadataTableStreamName => SK.UncompressedTable,
                EC.GUIDStreamName => SK.Guid,
                EC.MinimalDeltaMetadataTableStreamName => SK.MinimalDeltaTable,
                EC.StandalonePdbStreamName => SK.StandalonePdb,
                _ => SK.None,
            };

        string ReadAlignedAsciString(N4 n)
        {
            Span<char> dst = stackalloc char[32];
            var i = 0u;
            var finished = false;
            while(i < 32 && !finished)
            {
                var data = bytes(Read<uint>());
                for(var j=0; j<4; j++)
                {
                    ref readonly var c = ref skip(data,j);
                    if(c == 0)
                    {
                        finished = true;
                        break;
                    }
                    
                    seek(dst, i++) = (char)c;
                }
                if(finished)
                    break;
            }
            return sys.@string(slice(dst, 0, i));
        }

        [MethodImpl(Inline)]
        public MetadataRoot ReadMetadataRoot()
        {
            var dst = new MetadataRoot();
            dst.Assembly = AssemblyKey;
            dst.BaseAddress = Source.BaseAddress;
            dst.Signature = Require.equal(Read<uint>(), EcmaConstants.COR20MetadataSignature);
            dst.MajorVersion = Read<ushort>();
            dst.MinorVersion = Read<ushort>();
            dst.Reserved = Read<uint>();
            dst.IdentitySize = Read<uint>();
            var version = Read(dst.IdentitySize);
            dst.MetadataVersion = text.utf8(version);
            Require.equal(Read<ushort>(),0);
            dst.StreamCount = Read<ushort>();
            for(var i=0; i<dst.StreamCount; i++)
            {
                var header = new EcmaStreamHeader();
                header.Offset = Read<uint>();
                header.Size = Read<uint>();
                header.Name = ReadAlignedAsciString(n4);   
                header.StreamKind = StreamKind(header.Name);
                switch(header.StreamKind)
                {
                    case SK.Blob:
                        dst.BlobStreamHeader = header;
                    break;
                    case SK.Guid:
                        dst.GuidStreamHeader = header;
                    break;
                    case SK.String:
                        dst.StringStreamHeader = header;
                    break;
                    case SK.UserString:
                        dst.UserStringStreamHeader = header;
                    break;
                    case SK.CompressedTable:
                        dst.TableStreamHeader = header;
                        break;
                }
            }
            dst.TableOffset = Position;
            return dst;
        }
    }
}