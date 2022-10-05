export interface Kinded<K> {
    kind:K
}

export interface Class<K,C> extends Kinded<K> {
    class:C
}