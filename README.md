[![](https://img.shields.io/nuget/v/soenneker.dtos.results.api.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.results.api/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.results.api/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.results.api/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dtos.results.api.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dtos.results.api/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dtos.results.api/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dtos.results.api/actions/workflows/codeql.yml)

# Soenneker.Dtos.Results.Api

A generic container for API responses with ProblemDetails support.

## Install

```bash
dotnet add package Soenneker.Dtos.Results.Api
```

## What you get

- `ApiResult<T>` — A generic container for API responses with ProblemDetails support.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ApiResult<T>.Value` | The value returned if the operation was successful. | The value returned if the operation was successful. |
| `ApiResult<T>.Problem` | RFC 7807 problem details when the operation fails. | RFC 7807 problem details when the operation fails. |
| `ApiResult<T>.IsSuccess` | True if the result represents a success; false if it contains a problem. | True if the result represents a success; false if it contains a problem. |
| `ApiResult<T>.Failure(problem)` | Creates a failed result with problem details. | Returns `ApiResult<T>`. |
