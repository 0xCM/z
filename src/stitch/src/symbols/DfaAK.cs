//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Dfa<A,K>
        where A : unmanaged
        where K : unmanaged
    {
        readonly Index<DfaState<K>> _States;

        readonly Index<DfaState<K>> _Terminals;

        public readonly Alphabet<A> Alphabet;

        public ReadOnlySpan<DfaState<K>> States
        {
            [MethodImpl(Inline)]
            get => _States.View;
        }

        public ReadOnlySpan<DfaState<K>> Terminals
        {
            [MethodImpl(Inline)]
            get => _Terminals.View;
        }

        public DfaState<K> InitialState {get;}

        public DfaState<K> CurrentState {get; private set;}

        public void Process(ReadOnlySpan<K> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                CurrentState = Evaluate(src[i]);
        }

        protected abstract DfaState<K> Evaluate(K src);

        protected Dfa(Alphabet<A> alphabet, DfaState<K>[] states, DfaState<K>[] terminals, DfaState<K> s0)
        {
            Alphabet = alphabet;
            _States = states;
            _Terminals = terminals;
            InitialState = s0;
        }
    }
}