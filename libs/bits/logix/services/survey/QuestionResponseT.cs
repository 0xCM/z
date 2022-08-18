//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using api = Surveys;

    /// <summary>
    /// Defines a response to a survey question
    /// </summary>
    /// <typeparam name="T">The primal survey representation type</typeparam>
    public readonly struct QuestionResponse<T> : ITextual
        where T : unmanaged
    {
        public uint QuestionId {get;}

        public QuestionChoice<T>[] Chosen {get;}

        public QuestionResponse(uint questionId, params QuestionChoice<T>[] chosen)
        {
            QuestionId = questionId;
            Chosen = chosen;
        }


        public string Format()
            => api.format(this, false, Chars.Comma);

        public string Format(bool bracket, char sep)
            => api.format(this, bracket, sep);

        public override string ToString()
            => Format();
    }
}