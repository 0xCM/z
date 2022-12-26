//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
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

        public readonly string Type;
        
        public readonly ToolCmdArgs Args;

        public readonly CmdId CmdId;

        [MethodImpl(Inline)]
        public ToolCmd(Tool tool, string type, params ToolCmdArg[] args)
        {            
            Tool = tool;
            Type = type;
            Args = args;
            CmdId = new (type);            
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Tool.Hash | (Hash32)sys.hash(Type) | Args.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => CmdApi.format(this);

        public override string ToString()
            => Format();

        public static ToolCmd Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmd(Actor.Empty, EmptyString);
        }

        ToolCmdArgs IToolCmd.Args
            => Args;

        Tool IToolCmd.Tool
             => Tool;

        string IToolCmd.Type 
            => Type;

        CmdId ICmd.CmdId 
            => CmdId;
    }
}