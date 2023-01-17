namespace uCondo.Galdino.BootStraper.Configurations.Environments;

public class RouterEnvironments
{
    public string? GetEnvByName(string name) => Environment.GetEnvironmentVariable(name);
}