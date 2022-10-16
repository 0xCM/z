//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct EcmaFieldRow
    {
        public const string TableId = "clr.fields";

        public EcmaArtifactRef Key;

        public EcmaToken DeclaringType;

        public EcmaToken CilType;

        public FieldAttributes Attributes;

        public MemoryAddress Address;

        public bool IsStatic;
    }
}