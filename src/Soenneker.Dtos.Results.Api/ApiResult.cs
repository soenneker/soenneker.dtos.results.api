using Newtonsoft.Json;
using Soenneker.Dtos.ProblemDetails;
using System.Text.Json.Serialization;
using Soenneker.Attributes.PublicOpenApiObject;

namespace Soenneker.Dtos.Results.Api;

/// <summary>
/// A generic container for API responses with ProblemDetails support.
/// </summary>
[PublicOpenApiObject]
public sealed class ApiResult<T>
{
    /// <summary>
    /// The value returned if the operation was successful.
    /// </summary>
    [JsonPropertyName("value")]
    [JsonProperty("value")]
    public T? Value { get; set; }

    /// <summary>
    /// RFC 7807 problem details when the operation fails.
    /// </summary>
    [JsonPropertyName("problem")]
    [JsonProperty("problem")]
    public ProblemDetailsDto? Problem { get; set; }

    /// <summary>
    /// True if the result represents a success; false if it contains a problem.
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsSuccess => Problem is null;

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static ApiResult<T> Success(T value) => new() { Value = value };

    /// <summary>
    /// Creates a failed result with problem details.
    /// </summary>
    public static ApiResult<T> Failure(ProblemDetailsDto problem) => new() { Problem = problem };
}