//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LegalIdentityOptions
    {
        public readonly char TypeArgsOpen;

        public readonly char TypeArgsClose;

        public readonly char ArgsOpen;

        public readonly char ArgsClose;

        public readonly char ArgSep;

        public readonly char ModSep;

        [MethodImpl(Inline)]
        public LegalIdentityOptions(char TypeArgsOpen, char TypeArgsClose, char ArgsOpen, char ArgsClose, char ArgSep, char ModSep)
        {
            this.TypeArgsOpen = TypeArgsOpen;
            this.TypeArgsClose = TypeArgsClose;
            this.ArgsOpen = ArgsOpen;
            this.ArgsClose = ArgsClose;
            this.ArgSep = ArgSep;
            this.ModSep = ModSep;
        }
    }
}