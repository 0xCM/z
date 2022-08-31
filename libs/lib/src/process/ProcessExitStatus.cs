//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/OmniSharp/omnisharp-roslyn
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ProcessExitStatus
    {
        public readonly int Code;

        public readonly bool Started;

        public readonly bool TimedOut;

        public bool Succeeded
        {
            [MethodImpl(Inline)]
            get => Code == 0;
        }

        public bool Failed
        {
            [MethodImpl(Inline)]
            get => Code != 0 || !Started || TimedOut;
        }

        [MethodImpl(Inline)]
        public ProcessExitStatus(int code, bool started = true, bool timedOut = false)
        {
            Code = code;
            Started = started;
            TimedOut = timedOut;
        }

        public override string ToString()
        {
            var suffix = string.Empty;
            if (!Started)
            {
                suffix = " (not started)";
            }
            else if (TimedOut)
            {
                suffix = " (timed out)";
            }

            return Code.ToString() + suffix;
        }
    }
}