//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json.Nodes;

    public interface IJsonNode
    {
        //
        // Summary:
        //     Gets or sets the element at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to get or set.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than 0 or index is greater than the number of properties.
        //
        //   T:System.InvalidOperationException:
        //     The current System.Text.Json.Nodes.JsonNode is not a System.Text.Json.Nodes.JsonArray.
        JsonNode? this[int index] {get;set;}

        //
        // Summary:
        //     Gets or sets the element with the specified property name. If the property is
        //     not found, null is returned.
        //
        // Parameters:
        //   propertyName:
        //     The name of the property to return.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     propertyName is null.
        //
        //   T:System.InvalidOperationException:
        //     The current System.Text.Json.Nodes.JsonNode is not a System.Text.Json.Nodes.JsonObject.
        JsonNode? this[string propertyName] {get;set;}

        //
        // Summary:
        //     Gets the options to control the behavior.
        JsonNodeOptions? Options {get;}

        //
        // Summary:
        //     Gets the parent System.Text.Json.Nodes.JsonNode. If there is no parent, null
        //     is returned. A parent can either be a System.Text.Json.Nodes.JsonObject or a
        //     System.Text.Json.Nodes.JsonArray.
        JsonNode? Parent {get;}

        //
        // Summary:
        //     Gets the root System.Text.Json.Nodes.JsonNode. If the current System.Text.Json.Nodes.JsonNode
        //     is a root, null is returned.
        JsonNode Root {get;}

        //
        // Summary:
        //     Casts to the derived System.Text.Json.Nodes.JsonArray type.
        //
        // Returns:
        //     A System.Text.Json.Nodes.JsonArray.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The node is not a System.Text.Json.Nodes.JsonArray.
        JsonArray AsArray();

        //
        // Summary:
        //     Casts to the derived System.Text.Json.Nodes.JsonObject type.
        //
        // Returns:
        //     A System.Text.Json.Nodes.JsonObject.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The node is not a System.Text.Json.Nodes.JsonObject.
        public JsonObject AsObject();

        //
        // Summary:
        //     Casts to the derived System.Text.Json.Nodes.JsonValue type.
        //
        // Returns:
        //     A System.Text.Json.Nodes.JsonValue.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The node is not a System.Text.Json.Nodes.JsonValue.
        public JsonValue AsValue();

        //
        // Summary:
        //     Gets the JSON path.
        //
        // Returns:
        //     The JSON Path value.
        public string GetPath();

        //
        // Summary:
        //     Gets the value for the current System.Text.Json.Nodes.JsonValue.
        //
        // Type parameters:
        //   T:
        //     The type of the value to obtain from the System.Text.Json.Nodes.JsonValue.
        //
        // Returns:
        //     A value converted from the System.Text.Json.Nodes.JsonValue instance.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     The current System.Text.Json.Nodes.JsonNode cannot be represented as a {TValue}.
        //
        //   T:System.InvalidOperationException:
        //     The current System.Text.Json.Nodes.JsonNode is not a System.Text.Json.Nodes.JsonValue
        //     or is not compatible with {TValue}.
        public T GetValue<T>();
    }
}