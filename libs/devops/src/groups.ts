export {}

export type ToolGroupName =
    | "tools"
    | "system"

export type ApiGroupName =
    | "api"
    | "db"

export type GroupName =
    | ToolGroupName
    | ApiGroupName

export type Group<G> = {
    Group:G
}

export type ToolGroup = Group<ToolGroupName>

export type ApiGroup = Group<ApiGroupName>

export type CmdGroup = Group<GroupName>
    
    