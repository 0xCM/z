//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack =1,Size=8*8)]
    public record struct OperandClasses
    {
        public const byte MaxCount = 7;

        public static OperandClasses init(params OperandClass[] src)
            => new(src);

        public OperandClasses(params OperandClass[] src)
        {
            var count = math.min((byte)src.Length,MaxCount);
            seek(bytes(this),63) = count;
            for(var i=0; i<count; i++)                
                seek(Data,i) = skip(src,i);            
        }

        Span<OperandClass> Data
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<OperandClass>(sys.bytes(this));
        }

        public ref byte Count
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(bytes(this),63);
        }

        public ref OperandClass this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Data,i);
        }

        public ref OperandClass this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Data,i);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Count; i++)
            {
                if(i!=0)
                    dst.Append(" | ");
                
                dst.Append(this[i]);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public static OperandClasses Empty => new(sys.empty<OperandClass>());
    }


    public readonly record struct OperandClass
    {
        public readonly asci8 Name;

        [MethodImpl(Inline)]
        public OperandClass(asci8 name)
        {
            Name = name;
        }
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }
}
