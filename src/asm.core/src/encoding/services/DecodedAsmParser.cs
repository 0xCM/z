//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class DecodedAsmParser
    {
        public static DecodedAsmParser create(CompositeDispenser dispenser)
            => new DecodedAsmParser(dispenser);

        List<DecodedAsmBlock> Target;

        Hex16 BlockOffset;

        AsmAddressLabel BlockBase;

        CompositeDispenser Dispenser;

        DecodedAsmParser(CompositeDispenser dispenser)
        {
            Dispenser = dispenser;
        }

        public ReadOnlySpan<DecodedAsmBlock> Parsed()
            => Target.ViewDeposited();

        public Outcome ParseBlocks(string src)
        {
            Target = list<DecodedAsmBlock>();
            BlockOffset = 0;
            BlockBase = AsmAddressLabel.Empty;
            var result = Outcome.Success;
            var block = LocatedSymbol.Empty;
            var statemements = list<DecodedAsmStatement>();
            var lines = Lines.read(src);
            var count = lines.Length;
            var label = AsmBlockLabel.Empty;
            for(var m=0; m<count; m++)
            {
                ref readonly var line = ref skip(lines,m);
                ref readonly var content = ref line.Content;
                if(text.begins(content, Chars.Hash))
                    continue;

                if(AsmBlockLabel.parse(content, out label))
                {
                    if(statemements.Count != 0)
                        Target.Add(new DecodedAsmBlock(label, statemements.ToArray()));

                    BlockOffset = 0;
                    statemements.Clear();
                }
                else
                {

                }
            }

            if(statemements.Count != 0)
                Target.Add(new DecodedAsmBlock(label, statemements.ToArray()));


            return result;
        }
    }
}