using System;
using System.ComponentModel;
using System.Text.Json.Nodes;
using ModelContextProtocol.Server;

namespace MCP_medlink;
[McpServerToolType]
public class AppointmentValidation
{
    [McpServerTool]
    [Description("Проверяет, хватает ли данных для записи")]
    public static object CheckMissingData(
        int userId,
        string? name,
        string? complaint,
        string? priority
    )
    {
        var missing = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
            missing.Add("name");

        if (string.IsNullOrWhiteSpace(complaint))
            missing.Add("complaint");

        if (string.IsNullOrWhiteSpace(priority))
            missing.Add("priority");

        return new
        {
            userId,
            isComplete = missing.Count == 0,
            missingFields = missing
        };
    }
}