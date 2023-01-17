using Microsoft.AspNetCore.Builder;

namespace uCondo.Galdino.BootStraper.Configurations.Swagger;

public static class ApplicationBuildExtensionsSwagger
{
    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "UCondo >>> Teste do Galdino <<<");
            c.RoutePrefix = string.Empty;
        });
    }
}