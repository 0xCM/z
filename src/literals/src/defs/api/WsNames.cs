//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = WsAtoms;

    [LiteralProvider(ws)]
    public readonly struct WsNames
    {
        public const string tools = A.tools;

        public const string asm = A.asm;

        public const string tables = A.tables;

        public const string projects = A.projects;

        public const string sources = A.sources;

        public const string logs = A.logs;

        public const string gen = A.gen;

        public const string control = A.control;

        public const string output = A.output;

        public const string imports = A.imports;

        public const string api = A.api;

        public const string docs = A.docs;

        public const string envdb = A.envdb;
    }
}