import {Actor} from "../imports"
export type Name='git'
export type Tool = Actor<Name>

export * as Add from "./add"
export * as Clone from "./clone"
export * as Submodule from "./submodule"
