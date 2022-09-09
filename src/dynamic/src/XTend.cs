//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;
    }

    public static class XSvc
    {

    }

    struct Msg
    {

        public static MsgPattern<Count> JittingParts => "Jitting {0} parts";

        public static MsgPattern<PartId> JittingPart => "Jitting {0} members";

        public static MsgPattern<Count,PartId> JittedPart => "Jitted {0} {1} members";

        public static MsgPattern<dynamic,dynamic> JittedParts => "Jitted {0} members from {1} parts";

        public static MsgPattern<Assembly,uint> EmittingResources => "Emitting {1} {0} resources";
    }
}