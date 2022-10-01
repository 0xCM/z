export type Edge<K,S,T> = {
    kind:K
    source:S
    target:T
}

export function edge<K,S,T>(kind:K, source:S, target:T) : Edge<K,S,T> {
    return {
        kind,
        source,
        target
    }
}