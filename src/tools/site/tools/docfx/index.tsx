import {Actor} from "../imports"
export type Name = `docfx`
export type Tool = Actor<Name>

export * from "./io"
export * from "./build"
export * from "./subcmd"

