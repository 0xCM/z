//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial class ApiCode
    {
        [Op]
        public static void gather(IWfChannel channel, IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, bool pll)
            => iter(jit(channel, src), member => dst.Add(gather(channel, member, dispenser)), pll);

        [Op]
        public static ReadOnlySeq<ApiEncoded> gather(IWfChannel channel, ReadOnlySpan<MethodEntryPoint> src, ICompositeDispenser dispenser)
            => parse(channel, raw(channel, dispenser, src)).Values.Array().Sort();

        [Op]
        static ConcurrentBag<ApiHostMembers> jit(IWfChannel channel, IApiPartCatalog src)
        {
            var members = bag<ApiHostMembers>();
            iter(src.ApiHosts, host => ClrJit.jit(host, members, channel));
            iter(src.ApiTypes, type => ClrJit.jit(type, members, channel));      
            return members;          
        }

        [Op]
        static Outcome gather(in RawMemberCode raw, Span<byte> buffer, out CollectedCodeExtract dst)
        {
            var result = Outcome.Success;
            var uri = raw.Uri;
            if(raw.StubCode != raw.Stub.Encoding)
            {
                result = (false,$"Stub code mismatch for ${uri}: neq(stub:{raw.StubCode}, stub.encoding:{raw.Stub.Encoding}");
                dst = CollectedCodeExtract.Empty;
            }
            else
            {
                var code = slice(buffer, 0, Bytes.readz(ZeroLimit, raw.Target, buffer));
                dst = new CollectedCodeExtract(raw, code.ToArray());
            }

            return result;
        }

        [Op]
        static CollectedHost gather(IWfChannel channel, ApiHostMembers src, ICompositeDispenser dst)
            => new (src, gather(channel, entries(src.Members), dst));

        [Op]
        static Index<RawMemberCode> raw(IWfChannel channel, ICompositeDispenser dispenser, ReadOnlySpan<MethodEntryPoint> src)
        {
            var code = sys.alloc<RawMemberCode>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var entry = ref skip(src,i);
                var buffer = sys.bytes(Cells.alloc(w64));
                ByteReader.read5(entry.Location.Ref<byte>(), buffer);
                seek(code, i) = raw(channel, entry, dispenser);
            }
            return code;
        }

        [Op]
        static RawMemberCode raw(IWfChannel channel, MethodEntryPoint src, ICompositeDispenser dispenser)
        {
            var dst = new RawMemberCode();
            dst.Entry = src.Location;
            dst.Uri = src.Uri;
            var target = stub(src.Location, out dst.StubCode);
            dst.Target = target;
            if(target != src.Location)
            {
                dst.Disp = AsmRel.disp32(dst.StubCode.Bytes);
                dst.Stub = AsmRel.stub32(src.Location, target);
                dst.Token = token(dispenser, src, target);
            }
            else
                dst.Token = token(dispenser, src);
            return dst;
        }        
    }
}