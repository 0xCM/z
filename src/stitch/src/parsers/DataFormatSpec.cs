//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly partial struct DataFormatSpec
    {
        public readonly ulong Kind;

        public readonly byte Width;

        public readonly SeqStyleKind SeqStyle;

        public readonly text7 Delimiter;

        [MethodImpl(Inline)]
        public DataFormatSpec(ulong kind, byte width = 0, SeqStyleKind style = 0, string delimiter = EmptyString)
        {
            Kind = kind;
            Delimiter = delimiter;
            Width = width;
            SeqStyle = style;
        }

        public string Format(ReadOnlySpan<byte> src)
        {
            var dst = EmptyString;
            switch(Kind)
            {
                case 3: // signed hex
                    switch(Width)
                    {
                        case 8:
                            dst = FormatSignedHex(src, NativeSizeCode.W8);
                        break;
                        case 16:
                            dst = FormatSignedHex(src, NativeSizeCode.W16);
                        break;
                        case 32:
                            dst = FormatSignedHex(src, NativeSizeCode.W32);
                        break;
                        case 64:
                            dst = FormatSignedHex(src, NativeSizeCode.W64);
                        break;
                    }
                break;
            }
            return dst;
        }

        static string FormatSignedHex(ReadOnlySpan<byte> src, NativeSize size)
        {
            var data = slice(src ,0, size.ByteCount);
            var length = size.ByteCount;
            var dst = EmptyString;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                {
                    var value = @as<sbyte>(data);
                    if(value < 0)
                        dst = RP.format("-{0}",(((byte)((~((byte)value) + 1))).FormatHex(zpad:false, uppercase:true)));
                    else
                        dst = ((byte)value).FormatHex(zpad:false, uppercase:true);
                }
                break;
                case NativeSizeCode.W16:
                {
                    var value = @as<short>(data);
                    if(value < 0)
                        dst = RP.format("-{0}", ((ushort)((~((ushort)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((ushort)value).FormatHex(zpad:false, uppercase:true));
                }
                break;
                case NativeSizeCode.W32:
                {
                    var value = @as<int>(data);

                    if(value < 0)
                        dst = RP.format("-{0}",((uint)((~((uint)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((uint)value).FormatHex(zpad:false, uppercase:true));
                }
                break;
                case NativeSizeCode.W64:
                {
                    var value = @as<long>(data);
                    if(value < 0)
                        dst = RP.format("-{0}", ((ulong)((~((ulong)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((ulong)value).FormatHex(zpad:false, uppercase:true));

                }
                break;
            }
            return dst;
        }

        public enum SeqStyleKind : byte
        {
            Default,

            Adjacent,

            Delimited,
        }
    }
}