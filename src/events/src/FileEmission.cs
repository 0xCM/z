//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a file emission payload
    /// </summary>
    public readonly record struct FileEmission
    {                
        public readonly ExecToken Token;

        public readonly FilePath Target;

        public readonly Count Count;

        [MethodImpl(Inline)]
        public FileEmission(ExecToken token, FilePath target, Count count)
        {
            Token = token;
            Target = target;
            Count = count;
        }

        public bool Succeeded
        {
            [MethodImpl(Inline)]
            get => Count >= 0;
        }

        [MethodImpl(Inline)]
        public FileEmission WithCount(Count count)
            => new FileEmission(Token, Target, count);

        [MethodImpl(Inline)]
        public FileEmission WithToken(ExecToken token)
            => new FileEmission(token, Target, Count);

        public static FileEmission Empty => new FileEmission(ExecToken.Empty, FilePath.Empty, -1);
    }
}