//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class XedModels
{
    public class ChipInstructions 
    {
        ConstLookup<ChipCode, ReadOnlySeq<FormImport>> Lookup;

        public readonly ReadOnlySeq<ChipCode> Chips;

        internal ChipInstructions(ConcurrentDictionary<ChipCode, ReadOnlySeq<FormImport>> src)
        {
            Lookup = src;
            Chips = src.Keys.Array();
        }

        public ReadOnlySeq<FormImport> Forms(ChipCode chip)
            => Lookup[chip];

        public ParallelQuery<Paired<ChipCode,ReadOnlySeq<FormImport>>> Query()
            => from chip in Chips.AsParallel() select Tuples.paired(chip, Lookup[chip]);

        public ReadOnlySeq<FormImport> this[ChipCode chip]
            => Lookup[chip];
    }
}
