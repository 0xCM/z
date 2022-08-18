//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = BitShiftClass;
    using I = IApiBitShiftClass;

    partial struct ApiClasses
    {
        public readonly struct Sll : I { K I.Kind => K.Sll; }

        public readonly struct Sllv : I { K I.Kind => K.Sllv; }

        public readonly struct Srl : I { K I.Kind => K.Srl; }

        public readonly struct Srlv : I { K I.Kind => K.Srlv; }

        public readonly struct Rotl : I { K I.Kind => K.Rotl; }

        public readonly struct Rotr : I { K I.Kind => K.Rotr; }
    }
}