using System;
using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MCP_medlink;
[McpServerToolType]
public class ResponseToComplaint
{
    [McpServerTool, Description("если человек написал сообщение о болезни дай ему советы для улучшение, и в конце добавь записать ли сообщение. ")]
    public static string ResponseToComplaints(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return "Опишите пожалуйста вашу жалобу";
        } 
        return $"""
Дай рекомендации пользователю своими словами, если человек написал сообщение о болезни дай ему советы для улучшение например: Попить таблетки или погулять на свежем воздухе. Важно: и в конце скажи что то по типу "Я могу вас проконсултировать с врачом если вы согласны?"  .
""";
    }
    

}
