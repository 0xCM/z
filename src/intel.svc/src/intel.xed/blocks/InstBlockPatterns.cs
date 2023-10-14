//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
using System.Linq;

using static XedModels;

partial class XedZ
{
    public sealed class InstBlockPatterns
    {
        readonly ConcurrentDictionary<Key,InstBlockPattern> Lookup;

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
                Require.invariant(Lookup.TryAdd(new(pattern.Form, pattern.Index), pattern));
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


        public IEnumerable<InstBlockPattern> Match(XedInstForm form, MachineMode mode)
        {
            var i = z8;
            while(Lookup.TryGetValue(new Key(form,i++), out var pattern))
            {
                if(pattern.Mode != MachineMode.Not64)
                    yield return pattern;
            }
        }

        readonly record struct Key
        {
            readonly XedInstForm Form;

            readonly ushort Index;

            public Key(XedInstForm form, byte index)
            {
                Form = form;
                Index = index;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (uint)Form | ((uint)Index << 16);
            }

            public override int GetHashCode()
                => Hash;

            public bool Equals(Key src)
                => Form == src.Form && Index == src.Index;
        }   
    }
}