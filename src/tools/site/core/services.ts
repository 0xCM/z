export interface Provider {
}

export interface Service<P extends Provider> {
        provider:P
}
