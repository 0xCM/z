//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedZ
{
    public abstract class FormRule
    {
        public readonly string Name;

        protected FormRule(string name)
        {
            Name = name;
        }

        public abstract string Format();

        public override string ToString()
            => Format();
    }
}
