//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct ExprPatterns
    {
        public const char Choice = '|';

        public const string Definition = "{0} := {1}";

        public const string BinaryChoice = "{0} | {1}";

        public const string SourceToTarget = "{0} -> {1}";

        public const string TargetToSource = "{0} <- {1}";

        public const string BranchCase = SourceToTarget + ",";

        public const string AngledSlot0 = "<{0}>";

        public const string AngledSlot1 = "<{1}>";

        public const string AngledSlot2 = "<{2}>";

        public const string RPBetween = "[{0},{1}]";

        public const string InclusiveRange = "[{0}..{1}]";

        public const string AttribVal = "{0}:{1}";

        public const string True = "true";

        public const string False = "false";

        public const string PackedSlots3="{0}{1}{2}";

        public const string PaddedSlots3="{0} {1} {2}";

        public const string UntypedVar = "var:{0}";

        public const string TypedVar = "var<{0}>:{1}";

        public const string List = "[{0}]";

        public const string ListOpen = "[";

        public const string ListClose = "]";

        public const string Eval = "{0}:{1} -> {2}";

        public const string Binding = SourceToTarget;
    }
}