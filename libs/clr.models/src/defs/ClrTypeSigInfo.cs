//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A succinct type signature
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClrTypeSigInfo
    {
        public const string TableId = "clr.typesigs";

        [Render(32)]
        public string DisplayName;

        [Render(12)]
        public string Modifier;

        [Render(16)]
        public bool IsOpenGeneric;

        [Render(16)]
        public bool IsClosedGeneric;

        [Render(12)]
        public bool IsByRef;

        [Render(12)]
        public bool IsIn;

        [Render(12)]
        public bool IsOut;

        [Render(12)]
        public bool IsPointer;

        [Render(12)]
        public bool IsArray;

        public static ClrTypeSigInfo Empty
        {
            get
            {
                var dst = new ClrTypeSigInfo();
                dst.DisplayName = EmptyString;
                dst.Modifier = EmptyString;
                return dst;
            }
        }
    }
}