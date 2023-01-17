using Microsoft.AspNetCore.Builder;
using uCondo.Galdino.BootStraper.Configurations.Exceptions;

namespace uCondo.Galdino.BootStraper.Configurations.Cors;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}