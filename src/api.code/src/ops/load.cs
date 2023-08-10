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
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, PartName part)
        {
            load(channel, src, part, out var seq, out var code);
            return members(Dispense.composite(), seq, code);
        }

        [Op]
        static void load(IWfChannel channel, IApiPack src, PartName part, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = member(channel, src, part);
            data = bincode(channel, src, part);
        }

        [Op]
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, ICompositeDispenser symbols, ApiHostUri host)
        {
            load(channel, src, host, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, ICompositeDispenser symbols, PartName part)
        {
            load(channel, src, part, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static void load(IWfChannel channel,  IApiPack src, ApiHostUri host, out Seq<EncodedMember> index, out BinaryCode data)
        {
            AsmBytes.hexdat(src.HexExtractPath(host), out data).Require();
            parse(src.CsvExtractPath(host), out index).Require();
        }
        
        [Op]
        static Seq<EncodedMember> member(IWfChannel channel, IApiPack src, PartName part)
        {
            var dst = Seq<EncodedMember>.Empty;
            var result = parse(src.CsvExtractPath(part), out dst);
            if(result.Fail)
            {
                channel.Error(result.Message);
                sys.@throw($"{part.Format()} member load failure");
            }
            return dst;
        }

        [Op]
        static BinaryCode bincode(IWfChannel channel, IApiPack src, PartName part)
        {
            var dst = BinaryCode.Empty;
            var result = AsmBytes.hexdat(src.HexExtractPath(part), out dst);
            if(result.Fail)
            {
                channel.Error(result.Message);
                sys.@throw(result.Message);
            }
            return dst;
        }

        [Op]
        static ApiMemberCode members(ICompositeDispenser dispenser, Index<EncodedMember> src, BinaryCode code)
        {
            var dst = new ApiMemberCode.EncodingData();
            src.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var offset = 0u;
            var count = src.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > code.Length)
                    @throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;
                ApiIdentity.parse(info.Uri, out var uri).Require();
                var e = new MethodEntryPoint(info.EntryAddress, Require.notnull(uri), info.Sig);
                seek(tokens,i) = token(dispenser, e, info.TargetAddress);
                offset += size;
            }

            dst.Symbols = dispenser;
            dst.Members = src;
            dst.CodeBuffer = ManagedBuffer.pin(code.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return ApiMemberCode.own(dst);
        }
    }
}