//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline)]
        static string hex<T>(T src)
            where T : unmanaged
                => HexFormatter.format(src, false, false);
        [Op]
        public static string format(object data, PrimalCode code)
            => code switch {
                PrimalCode.String => cast<string>(data),
                PrimalCode.C16 => cast<char>(data).ToString(),
                PrimalCode.I8 => hex(cast<sbyte>(data)),
                PrimalCode.U8 => hex(cast<byte>(data)),
                PrimalCode.I16 => hex(cast<short>(data)),
                PrimalCode.U16 => hex(cast<ushort>(data)),
                PrimalCode.I32 => hex(cast<int>(data)),
                PrimalCode.U32 => hex(cast<uint>(data)),
                PrimalCode.I64 => hex(cast<long>(data)),
                PrimalCode.U64 => hex(cast<ulong>(data)),
                PrimalCode.F32 => hex(cast<float>(data)),
                PrimalCode.F64 => hex(cast<double>(data)),
                PrimalCode.F128 => hex(cast<decimal>(data)),
                PrimalCode.U1 => cast<bool>(data).ToString(),
                _ =>  $"{code} unrecognized"
            };

        [Op]
        public static string format(in FieldRef src)
        {
            var datatype = src.KindId;
            var data = src.Field.GetRawConstantValue();
            if(src.Field.FieldType.IsEnum)
                return data.ToString();
            return format(data, src.KindId);
        }
    }
}