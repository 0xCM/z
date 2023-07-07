//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedFlows
{
    public ChipMap CalcChipMap(FilePath src)
    {
        var kinds = Symbols.index<InstIsaKind>();
        var chip = ChipCode.INVALID;
        var chips = dict<ChipCode,ChipIsaKinds>();
        using var reader = src.LineReader(TextEncodingKind.Asci);
        while(reader.Next(out var line))
        {
            if(line.StartsWith(Chars.Hash))
                continue;

            var i = line.Index(Chars.Colon);
            if(i != -1)
            {
                var name = line.Left(i).Trim();
                if(blank(name))
                    continue;

                if(XedParsers.parse(name, out chip))
                {
                    if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                        Errors.Throw(Msg.DuplicateChipCode.Format(chip));
                }
                else
                    Errors.Throw(Msg.ChipCodeNotFound.Format(name));
            }
            else
            {
                var isaKinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<InstIsaKind>(x,0)).Where(x => x != 0).Array();
                chips[chip].Add(isaKinds);
                if(chips.TryGetValue(chip, out var entry))
                    entry.Add(isaKinds);
            }
        }
        var codes = Symbols.index<ChipCode>();
        var buffer = dict<ChipCode,InstIsaKinds>();
        for(var i=0; i<codes.Count; i++)
        {
            var code = codes[i].Kind;
            if(chips.TryGetValue(code, out var entry))
                buffer[code] = entry.Kinds;
            else
                buffer[code] = XedModels.InstIsaKinds.Empty;
        }
        return new ChipMap(buffer);
    }
}
