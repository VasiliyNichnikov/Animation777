namespace Machine
{
    /// <summary>
    /// Самый главный манагер по работе с автоматом
    /// </summary>
    public interface IMachineManager
    {
        void Init();
        
        void Run();
    }
}