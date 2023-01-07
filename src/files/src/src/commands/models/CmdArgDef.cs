//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool flag argument
    /// </summary>
    public readonly record struct CmdArgDef
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public readonly ushort Position;

        /// <summary>
        /// The flag name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The argument value
        /// </summary>
        public readonly dynamic Value;

        public readonly ArgPartKind Classifier;

        [MethodImpl(Inline)]
        public CmdArgDef(ushort pos, string name, ArgPrefix? prefix = null)
        {
            Position = pos;
            Name = name;
            Value = EmptyString;
            Classifier = ArgPartKind.Name | ArgPartKind.Position;
        }

        [MethodImpl(Inline)]
        public CmdArgDef(string name, ArgPrefix? prefix = null)
        {
            Position = 0;
            Name = name;
            Value = EmptyString;
            Classifier = ArgPartKind.Name;
        }

        public bool IsFlag
            => true;
    }
}