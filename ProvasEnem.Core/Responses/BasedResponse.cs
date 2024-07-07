﻿

namespace ProvasEnem.Core.Responses;

public class BasedResponse
{
    private readonly int _statusCode;
    public BasedResponse(string? data, string message, int statusCode)
    {
        Data = data;
        Message = message;
        _statusCode = statusCode;
    }

    public string? Data { get; set; }
    public string Message { get; set; } = string.Empty;

    public bool IsSucess 
        => _statusCode is >= 200 and <= 299;

}
