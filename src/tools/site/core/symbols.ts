export type Symbol<S> = {
    value:S
}

export type symbolic<S> = (s:S) => Symbol<S>

export function symbol<S>(value:S) : Symbol<S> {
    return {
        value
    }
}

export function expression<S>(value:Symbol<S>) {
    return `${value}`
}
