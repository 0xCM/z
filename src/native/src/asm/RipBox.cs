//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public struct RipBox
    {
        readonly MemoryAddress PhysicalBase;

        readonly MemoryAddress VirtualBase;

        public readonly ByteSize Size;

        MemoryAddress _IP;

        [MethodImpl(Inline)]
        public RipBox(MemoryAddress @base, ByteSize size)
        {
            PhysicalBase = @base;
            VirtualBase = 0u;
            Size = size;
            _IP = 0u;
        }

        [MethodImpl(Inline)]
        public RipBox(MemoryAddress @base, MemoryAddress virt, ByteSize size)
        {
            PhysicalBase = @base;
            VirtualBase = virt;
            Size = size;
            _IP = @base - virt;
        }

        public readonly MemoryAddress Base
        {
            [MethodImpl(Inline)]
            get => PhysicalBase - VirtualBase;
        }

        public readonly MemoryAddress Max
        {
            [MethodImpl(Inline)]
            get => Base + Size;
        }

        [MethodImpl(Inline)]
        public MemoryAddress IP()
            => _IP;

        [MethodImpl(Inline)]
        public bool IP(MemoryAddress src)
        {
            if(src <= Max && src >=Base)
            {
                _IP = src;
                return true;
            }
            else
                return false;
        }

        [MethodImpl(Inline)]
        public readonly bool Contains(MemoryAddress src)
            => src <= Max && src >=Base;

        [MethodImpl(Inline)]
        public bool Advance(Disp32 dx, out MemoryAddress dst)
        {
            var _next = _IP + (MemoryAddress)(int)dx;
            if(Contains(_next))
            {
                _IP = _next;
                dst = _IP;
                return true;
            }
            else
            {
                dst = 0u;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool Advance(byte sz, Disp32 dx, out MemoryAddress dst)
        {
            var _next = (uint)sz + (MemoryAddress)(int)dx + _IP;
            if(Contains(_next))
            {
                _IP = _next;
                dst = _IP;
                return true;
            }
            else
            {
                dst = 0u;
                return false;
            }
        }
    }
}