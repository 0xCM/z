//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        sealed class EmptyFlow : IFileFlowType
        {
            public static EmptyFlow Instance = new();

            public FileKind SourceKind => FileKind.None;

            public FileKind TargetKind => FileKind.None;

            public IActor Actor => EmptyActor.Instance;

            public dynamic Source => SourceKind;

            public dynamic Target => TargetKind;

            public string Format() => EmptyString;
        }

        sealed class EmptyActor : IActor
        {
            public static EmptyActor Instance = new();

            public Name Name => asci64.Null;

            public Hash32 Hash => 0;

            public bool IsEmpty => true;

            public bool IsNonEmpty => false;
        }
    }
}