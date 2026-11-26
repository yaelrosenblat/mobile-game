
public class ConfigService : IConfigService
{
    public EconomyConfig Economy { get; }

    public ConfigService(EconomyConfig economy)
    {
        Economy = economy;
    }
}
    