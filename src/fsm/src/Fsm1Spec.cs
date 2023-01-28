//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Fsm1Spec;
    using static Fsm1Spec.StateKinds;
    using static Fsm1Spec.EventKinds;
    using static Fsm1Spec.OutputKinds;

    public class Fsm1Spec : FsmSpec<EventKinds,StateKinds,OutputKinds>
    {
        public enum StateKinds : byte
        {
            S0, S1, S2, S3, S4, S5
        }

        public enum EventKinds: byte
        {
            E1, E2, E3, E4, E5, E6, E7
        }

        public enum OutputKinds : byte
        {
            O0, O1, O2, O3, O4, O5, O6, O7, O8, O9, O10
        }

        public override IEnumerable<FsmOutputRule<EventKinds,StateKinds,OutputKinds>> OutputRules
        {
            get
            {
                yield return (E1, S1, O0);
                yield return (E2, S2, O1);
                yield return (E3, S3, O2);
                yield return (E4, S4, O3);
                yield return (E4, S5, O4);
            }
        }

        public override IEnumerable<FsmTransitionRule<EventKinds,StateKinds>> TransRules
        {
            get
            {
                yield return (E1, S0, S1);
                yield return (E1, S1, S2);
                yield return (E1, S2, S3);
                yield return (E1, S3, S4);
                yield return (E1, S4, S5);
            }
        }
    }
}