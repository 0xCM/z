//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using static sys;

partial class XedModels
{
    public class FormInstructions
    {
        readonly ConcurrentDictionary<XedInstForm,ConcurrentBag<Instruction>> Lookup;

        public FormInstructions(ConcurrentDictionary<XedInstForm,ConcurrentBag<Instruction>> lookup)
        {
            Lookup = lookup;
        }

        public ParallelQuery<XedInstForm> Forms => Lookup.Keys.AsParallel();

        public IEnumerable<Instruction> Find(XedInstForm src)
        {
            if(Lookup.TryGetValue(src, out var inst))
                return inst;
            else
                return seq<Instruction>();
        }
    }
}
