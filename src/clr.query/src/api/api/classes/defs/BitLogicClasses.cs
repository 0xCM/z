//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = BitLogicClass;
    using I = IApiBitLogicClass;

    partial struct ApiClasses
    {
        public readonly struct And : I { K I.Kind => K.And; }

        public readonly struct Or : I { K I.Kind => K.Or; }

        public readonly struct Xor : I { K I.Kind => K.Xor; }

        public readonly struct Nand : I { K I.Kind => K.Nand; }

        public readonly struct Nor : I { K I.Kind => K.Nor; }

        public readonly struct Xnor : I { K I.Kind => K.Xnor; }

        public readonly struct Impl : I { K I.Kind => K.Impl; }

        public readonly struct NonImpl : I { K I.Kind => K.NonImpl; }

        public readonly struct CImpl : I { K I.Kind => K.CImpl; }

        public readonly struct CNonImpl : I { K I.Kind => K.CNonImpl; }

        public readonly struct Not : I { K I.Kind => K.Not; }

        public readonly struct Select : I { K I.Kind => K.Select; }

        public readonly struct True : I { K I.Kind => K.True; }

        public readonly struct False : I { K I.Kind => K.False; }

        public readonly struct LProject : I { K I.Kind => K.LProject; }

        public readonly struct RProject : I { K I.Kind => K.RProject; }

        public readonly struct LNot : I { K I.Kind => K.LNot; }

        public readonly struct RNot : I { K I.Kind => K.RNot; }
    }
}