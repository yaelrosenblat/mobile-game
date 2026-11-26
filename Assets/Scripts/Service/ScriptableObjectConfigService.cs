using UnityEngine;

public class ScriptableObjectConfigService : IConfigService
{
    public EconomyConfig Economy { get; }
    public ScriptableObjectConfigService(EconomyConfig economy) => Economy = economy;
}

