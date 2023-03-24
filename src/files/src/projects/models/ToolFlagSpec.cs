//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    /// <summary>
    /// Defines a tool flag argument
    /// </summary>
    public readonly record struct ToolFlagSpec
    {
        /// <summary>
        /// The flag name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The flag description
        /// </summary>
        public readonly string Description;

        [MethodImpl(Inline)]
        public ToolFlagSpec(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public string Format()
            => string.Format("{1,-34} {2}", Name, Description);

        public override string ToString()
            => Format();
    }
}