#nullable enable
using System.Collections.Generic;
using Machine;

namespace Algorithm
{
    /// <summary>
    /// Алгоритм выдающий случайный элемент(-ы)
    /// </summary>
    public interface IRandomItemAlgorithm
    {
        IReadOnlyCollection<TypeOfItem> GenerateItems(int numberItems);
    }
}