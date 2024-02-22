#nullable enable
using Machine;

namespace Factory
{
    /// <summary>
    /// Создатель предметов в автомат
    /// </summary>
    public interface IItemFactory
    {
        ItemView Create();
    }
}