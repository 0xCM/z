//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;

    partial class ApiCode
    {
        [Op]
        public static ApiMemberCode load(IApiPack src, PartId part, WfEmit channel)
        {
            load(src, part, channel, out var seq, out var code);
            return members(Dispense.composite(), seq, code);
        }

        [Op]
        static void load(IApiPack src, PartId part, WfEmit channel, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = member(src, part, channel);
            data = code(src, part, channel);
        }

        [Op]
        static Seq<EncodedMember> member(IApiPack src, PartId part, WfEmit channel)
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
        static BinaryCode code(IApiPack src, PartId part, WfEmit channel)
        {
            var dst = BinaryCode.Empty;
            var result = hexdat(src.HexExtractPath(part), out dst);
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
            var offsets = sys.alloc<uint>(count);
            var tokens = sys.alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > code.Length)
                    sys.@throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

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

        [Op]
        public static ApiMemberCode load(IApiPack src, ICompositeDispenser symbols, ApiHostUri host, WfEmit channel)
        {
            load(src, host, channel, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static ApiMemberCode load(IApiPack src, ICompositeDispenser symbols, PartId part, WfEmit channel)
        {
            load(src, part, channel, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static void load(IApiPack src, ApiHostUri host, WfEmit channel, out Seq<EncodedMember> index, out BinaryCode data)
        {
            hexdat(src.HexExtractPath(host), out data).Require();
            parse(src.CsvExtractPath(host), out index).Require();
        }
    }
}