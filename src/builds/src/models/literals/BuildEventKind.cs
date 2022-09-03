//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public enum BuildEventKind : byte
        {
            None,

            ProjectStarted,

            ProjectFinished,

            BuildStarted,

            BuildFinished,

            BuildWarning,

            BuildError,

            BuildStatus,

            BuildMessage
        }
    }
}