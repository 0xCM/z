//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public enum DepthIndicator : byte
        {
            None = 0,

            Bullet = (byte)'*',

            Hash = AsciCode.Hash,

            Dash = AsciCode.Dash,
        }
    }
}