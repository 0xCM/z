//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymDetailRow : IRecord<SymDetailRow>
    {
        public const string TableId = "symbol.details";

        public const byte FieldCount = 10;

        public Identifier TypeName;

        public ushort SymCount;

        public SymKey Index;

        public Identifier Name;

        public SymExpr Expr;

        public ushort NameSize;

        public ushort ExprSize;

        public BinaryCode NameData;

        public BinaryCode ExprData;

        public bool Hidden;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,8,8,20,20,10,10,48,48,5};
    }
}