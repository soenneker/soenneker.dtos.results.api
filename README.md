[![](https://img.shields.io/nuget/v/soenneker.dtos.results.api.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.results.api/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.results.api/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.results.api/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dtos.results.api.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.results.api/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.results.api/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.results.api/actions/workflows/codeql.yml)

# Soenneker.Dtos.Results.Api

A generic API response envelope that carries either a typed value or problem-details payload and works with both `System.Text.Json` and Newtonsoft.Json.

## Install

```bash
dotnet add package Soenneker.Dtos.Results.Api
```

## Create results

```csharp
using Soenneker.Dtos.ProblemDetails;
using Soenneker.Dtos.Results.Api;

ApiResult<OrderDto> success = ApiResult<OrderDto>.Success(order);

ApiResult<OrderDto> failure = ApiResult<OrderDto>.Failure(new ProblemDetailsDto
{
    Type = "https://api.example.com/problems/order-not-found",
    Title = "Order not found",
    Status = 404,
    Detail = "No order exists with id 42."
});
```

## Consume a result

```csharp
if (result.IsSuccess)
{
    OrderDto? order = result.Value;
}
else
{
    ProblemDetailsDto problem = result.Problem!;
}
```

`IsSuccess` is a convenience property and is not serialized. Its definition is simply `Problem is null`; it does not inspect `Value` or an HTTP status code. Consequently, a default `ApiResult<T>` is considered successful even though its value is null, and if both properties are populated the result is considered a failure.

The properties remain mutable for serializer compatibility, so prefer the `Success` and `Failure` factories when creating results. Null members are included or omitted according to your serializer settings. The DTO does not set an HTTP response's status code.
