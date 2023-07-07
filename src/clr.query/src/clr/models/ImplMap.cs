//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HandleFormatKind;

    /// <summary>
    /// Captures the content of a <see cref="InterfaceMapping"/>
    /// </summary>
    public record struct ImplMap : IExpr
    {
        /// <summary>
        /// The methods declared by an interface
        /// </summary>
        public Seq<MethodInfo> Specs;

        /// <summary>
        /// The interface type
        /// </summary>
        public Type SpecType;

        /// <summary>
        /// The methods that realize an interface implementation
        /// </summary>
        public Seq<MethodInfo> Impl;

        /// <summary>
        /// The type that declares the methods that realize an interface contract
        /// </summary>
        public Type ImplType;

        /// <summary>
        /// The number of interface members
        /// </summary>
        public uint OperationCount
        {
            [MethodImpl(Inline)]
            get => Specs.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Specs.IsEmpty || Impl.IsEmpty;
        }

        public string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<OperationCount; i++)
                Render(x => dst.AppendLine(x));
            return dst.ToString();
        }

        // https://mattwarren.org/2020/02/19/Under-the-hood-of-Default-Interface-Methods/
        public void Render(Action<string> receiver)
        {
            receiver(string.Format("{0} -> {1}", SpecType.DisplayName(), ImplType.DisplayName()));
            var count = OperationCount;
            for(var i=0u; i<count; i++)
            {
                try
                {
                    ClrMethodAdapter spec = Specs[i];
                    ClrMethodAdapter impl = Impl[i];

                    receiver($"  [{spec.MethodHandle.Format(Raw)} --> {impl.MethodHandle.Format(Raw)}]");
                    receiver($"  {spec.DeclaringType.DisplayName()}::{spec.DisplayName()} --> {impl.DeclaringType.DisplayName()}::{impl.DisplayName()}");
                    receiver(string.Format("    Spec(MethodHandle) {0} --> Impl(MethodHandle) {1}",
                        spec.MethodHandle.Format(HandleAddress),
                        impl.MethodHandle.Format(HandleAddress)
                        )
                    );

                    receiver(string.Format("    Spec(FunctionPtr) {0} --> Impl(FunctionPtr)  {1}",
                        spec.MethodHandle.Format(PointerAddress),
                        impl.MethodHandle.Format(PointerAddress)
                        )
                    );
                }
                catch(Exception)
                {
                    receiver("<error>");
                }
            }

        }

        public override string ToString()
            => Format();
    }
}