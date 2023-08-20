//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static HexOptionData;

    public readonly struct HexDataFormatter : IHexDataFormatter
    {
        [MethodImpl(Inline), Op]
        public static HexDataFormatter create(ulong? @base = null, ushort bpl = 20, bool labels = true)
            => new HexDataFormatter(new HexLineConfig(bpl, 16, labels), @base);

        public readonly HexLineConfig LineConfig;

        public readonly HexFormatOptions LabelConfig;

        readonly HexFormatOptions DataConfig;

        readonly MemoryAddress BaseAddress;

        [MethodImpl(Inline)]
        public HexDataFormatter(HexLineConfig config, ulong? @base = null)
        {
            LineConfig = config;
            BaseAddress = @base ?? 0;
            LabelConfig = HexFormatOptions.define(zpad:true, specifier: true, uppercase: false, prespec:false);
            DataConfig = HexDataOptions;
        }

        string FormatAddress(MemoryAddress src)
            => "0x" + string.Format(RP.pad(-LineConfig.AddressWidth),((ulong)src).ToString("X"));

        public string FormatLine(ReadOnlySpan<byte> data, ulong offset, char delimiter)
        {
            var line = text.emitter();
            var count = data.Length;
            if(LineConfig.LineLabels)
            {
                line.Append(FormatAddress(BaseAddress + offset));
                line.Append(delimiter);
                line.Append(Chars.Space);
            }

            line.Append(data.FormatHex());

            return line.Emit();
        }

        public void FormatLines(ReadOnlySpan<byte> data, Action<string> receiver)
        {
            var line = text.emitter();
            var count = data.Length;
            var offset = MemoryAddress.Zero;
            for(var i=0u; i<count; i++)
            {
                if(i % LineConfig.BytesPerLine == 0)
                {
                    if(i != 0)
                    {
                        receiver(line.ToString());
                        line.Clear();
                    }

                    if(LineConfig.LineLabels)
                    {
                        line.Append(FormatAddress(BaseAddress + offset));
                        line.Append(LineConfig.Delimiter);
                        line.Append(Chars.Space);
                    }
                }

                line.Append(skip(data,i).FormatHex(DataConfig));

                if(i != count - 1)
                    line.Append(Chars.Space);

                offset += 1;
            }

            var last = line.ToString();
            if(text.nonempty(last))
                receiver(last);
        }

        public ReadOnlySpan<string> FormatLines(ReadOnlySpan<byte> src)
        {
            const char delimiter = Chars.Space;
            var dst = list<string>();
            var line = text.emitter();
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                if(i % LineConfig.BytesPerLine == 0)
                {
                    if(i != 0)
                        dst.Add(line.Emit().Trim());

                    if(LineConfig.LineLabels)
                    {
                        line.Append(i.FormatHex(LabelConfig));
                        line.Append(delimiter);
                    }
                }

                line.Append(skip(src,i).FormatHex(DataConfig));
                line.Append(delimiter);
            }

            var last = line.Emit().Trim();
            if(nonempty(last))
                dst.Add(last);

            return dst.ToArray();
        }
    }
}