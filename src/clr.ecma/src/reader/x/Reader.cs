//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static EcmaReader EcmaReader(this EcmaFile src)
            => Ecma.reader(src);

        public static ReadOnlySeq<uint> Terminators(this EcmaStringHeap src)
            => EcmaHeaps.terminators(src);

        const TypeAttributes Forwarder = (TypeAttributes)0x00200000;

        // reference: D:\env\dev\dotnet\vendor\runtime\src\libraries\System.Reflection.Metadata\src\System\Reflection\System.Reflection.cs
        public static bool IsForwarder(this TypeAttributes flags)
        {
            return (flags & Forwarder) != 0;
        }
    }
}