//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct RunWf : ICmd<RunWf>
    {
        public const string CmdName = "run-wf";

        public @string WorkflowName;

        [MethodImpl(Inline)]
        public RunWf(@string name)
            => WorkflowName = name;

        [MethodImpl(Inline)]
        public bool Equals(RunWf src)
            => WorkflowName.Equals(src.WorkflowName);

        public override int GetHashCode()
            => WorkflowName.GetHashCode();

        public override bool Equals(object src)
            => src is RunWf c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator RunWf(string name)
            => new RunWf(name);

        [MethodImpl(Inline)]
        public static implicit operator RunWf(@string name)
            => new RunWf(name);

        public static bool operator ==(RunWf a, RunWf b)
            => a.Equals(b);

        public static bool operator !=(RunWf a, RunWf b)
            => !a.Equals(b);

        public static RunWf Empty => new RunWf(@string.Empty);
    }

}