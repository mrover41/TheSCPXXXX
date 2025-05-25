namespace _Game.Core.Interfaces
{
    public interface IPlayerModule
    {
        void Initialize(PlayerEventSystem events);
        void UpdateModule(float deltaTime);
    }
}