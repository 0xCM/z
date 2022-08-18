//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Artifact : IArtifact
    {
        public readonly string Classifier {get;}

        public readonly dynamic Location {get;}

        [MethodImpl(Inline)]
        public Artifact(string @class, dynamic locator)
        {
            Classifier = @class;
            Location = locator;
        }

        public string Format()
            => Location;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact((string kind, dynamic locator) src)
            => new Artifact(src.kind, src.locator);
    }
}