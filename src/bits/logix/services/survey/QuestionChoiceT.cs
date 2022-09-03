//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Surveys;

    /// <summary>
    /// Defines a choice in the context of a survey question
    /// </summary>
    /// <typeparam name="T">The primal survey representation type</typeparam>
    public readonly struct QuestionChoice<T> : ITextual
        where T : unmanaged
    {
        /// <summary>
        /// Uniquely identifies a choice relative to a question
        /// </summary>
        public T ChoiceId {get;}

        /// <summary>
        /// The meaning of the choice
        /// </summary>
        public string Label {get;}

        public string Title {get;}

        [MethodImpl(Inline)]
        public QuestionChoice(T id, string label, string title = null)
        {
            ChoiceId = id;
            Label = label;
            Title = title ?? api.title(id, label);
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}