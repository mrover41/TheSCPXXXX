public abstract class Plugin<TConfig> : IPlugin where TConfig : IConfig, new() {
    public TConfig Config { get; private set; } = new TConfig();

    public abstract void OnEnable();
    public abstract void OnDisable();
}