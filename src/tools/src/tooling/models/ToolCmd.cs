//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public record class ToolCmd : IToolCmd
    {
        public readonly Tool Tool;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ToolCmd(Tool tool, params CmdArg[] args)
        {            
            Tool = tool;
            Args = args;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Tool.Hash | Args.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Tooling.format(this);

        public override string ToString()
            => Format();

        public static ToolCmd Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmd(Actor.Empty, EmptyString);
        }

        CmdArgs IToolCmd.Args
            => Args;

        Tool IToolCmd.Tool
             => Tool;

        CmdId ICmd.CmdId 
            => EmptyString;
    }
}