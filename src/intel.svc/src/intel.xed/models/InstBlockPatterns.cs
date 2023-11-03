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
        public static PatternKey key(InstBlockPattern pattern)
            => new(pattern.Form, pattern.Mode, pattern.Lock, pattern.Index);

        public static int cmp(InstBlockPattern a, InstBlockPattern b)
        {
            var result = a.Form.CompareTo(b.Form);
            if(result == 0)
            {
                result = a.Mode.CompareTo(b.Mode);
                if(result == 0)
                {
                    result = a.Lock.CompareTo(b.Lock);
                    if(result == 0)
                        result = a.Operands.Format().CompareTo(b.Operands.Format());
                }
            }
            return result;
        }

        readonly ConcurrentDictionary<PatternKey,InstBlockPattern> Lookup;

        readonly Seq<InstBlockPattern> Data;

        public InstBlockPatterns(ParallelQuery<InstBlockPattern> src)
        {
            Lookup = new();
            Data = src.Array().Sort();
            var form = XedInstForm.Empty;
            var index = z8;
            for(var i=z16; i<Count; i++)
            {
                ref var pattern = ref Data[i];
                if(form != pattern.Form)
                {
                    form = pattern.Form;
                    index = 0;
                }
                pattern.Seq = i;
                pattern.Index = index++;
                Require.invariant(Lookup.TryAdd(key(pattern), pattern));
            }            
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

        public IEnumerable<InstBlockPattern> Match(XedInstForm form, MachineMode mode, bool @lock = false)
        {
            var i = z8;
            while(Lookup.TryGetValue(new PatternKey(form, mode, @lock, i++), out var pattern))
            {
                if(pattern.Mode != MachineMode.Not64)
                    yield return pattern;
            }
        }

        public static InstBlockPatterns Empty => new(sys.empty<InstBlockPattern>().AsParallel());
    }
}
