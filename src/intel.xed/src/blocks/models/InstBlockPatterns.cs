//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class XedModels
{
    public sealed class InstBlockPatterns
    {
        readonly ConcurrentDictionary<PatternKey,InstBlockPattern> Lookup;

        readonly ReadOnlySeq<InstBlockPattern> Data;

        public InstBlockPatterns(ReadOnlySeq<InstBlockPattern> data, ConcurrentDictionary<PatternKey,InstBlockPattern> src)
        {
            Lookup = src;
            Data = data;
        }        

        public ReadOnlySpan<InstBlockPattern> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly InstBlockPattern this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly InstBlockPattern this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public IEnumerable<InstBlockPattern> Match(XedInstForm form, bool @lock)
        {
            var i = z8;
            while(Lookup.TryGetValue(new PatternKey(form, MachineMode.Mode32x64, @lock, i++), out var pattern))
            {
                yield return pattern;
            }
            while(Lookup.TryGetValue(new PatternKey(form, MachineMode.Mode64, @lock, i++), out var pattern))
            {
                yield return pattern;
            }
        }

        public IEnumerable<InstBlockPattern> Match(XedInstForm form)
            => Data.Where(x => x.Form == form);
            
        public IEnumerable<InstBlockPattern> Match(XedInstForm form, MachineMode mode, bool @lock)
        {
            var i = z8;
            while(Lookup.TryGetValue(new PatternKey(form, mode, @lock, i++), out var pattern))
            {
                yield return pattern;
            }
        }

        public static InstBlockPatterns Empty => new(sys.empty<InstBlockPattern>(), sys.cdict<PatternKey,InstBlockPattern>());
    }
}