using System.Text.Json.Serialization;
using Bookish.Domain.Enums;
using RestaurantAPI.Domain.Entities;

namespace RestaurantAPI.Application.Handlers.Authentication.Register.Common;

public class OutputDto
{
    [JsonIgnore] public Status? Status { get; init; }

    [JsonIgnore] public string Message { get; init; }

    [JsonIgnore] public List<string> Errors { get; set; }

    public OutputDto()
    {
    }

    public OutputDto(Status status, string message, List<string> errors)
    {
        Status = status;
        Message = message;
        Errors = errors;
    }
}