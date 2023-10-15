//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    public readonly record struct InstCells
    {
        public readonly Seq<CellValue> Data;

        public readonly byte LayoutCount;

        [MethodImpl(Inline)]
        public InstCells(CellValue[] src)
        {
            Data = src;
            LayoutCount = 0;
        }

        [MethodImpl(Inline)]
        public InstCells(CellValue[] src, byte lCount)
        {
            Data = src;
            LayoutCount = lCount;
        }

        public ReadOnlySpan<CellValue> Values
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ReadOnlySpan<CellValue> Layout
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? default : sys.slice(Data.View, 0, LayoutCount);
        }

        public ReadOnlySpan<CellValue> Expr
        {
            [MethodImpl(Inline)]
            get => IsEmpty ?  default : sys.slice(Data.View, LayoutCount);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get =>  Data.IsNonEmpty;
        }

        public ref CellValue First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref CellValue this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref CellValue this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public byte Count
        {
            [MethodImpl(Inline)]
            get => (byte)Data.Count;
        }

        public byte ExprCount
        {
            [MethodImpl(Inline)]
            get => (byte)(Count - LayoutCount);
        }

        public bool Lock()
        {
            var result = false;
            for(var i=0; i<Count; i++)
            {
                ref readonly var cell = ref this[i];
                if(cell.Field == FieldKind.LOCK)
                {
                    result = cell.AsByte() == 1;
                    break;
                }
            }
            return result;
        }
        
        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();
    }
}
