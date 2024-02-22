using System.Collections.Generic;
using Machine;

namespace Algorithm
{
    /// <summary>
    /// Заготовка
    /// </summary>
    public class RandomItemAlgorithmBlank: IRandomItemAlgorithm
    {
        public IReadOnlyCollection<TypeOfItem> GenerateItems(int numberItems)
        {
            return new List<TypeOfItem> { TypeOfItem.Archer, TypeOfItem.Aim, TypeOfItem.Bomb };
        }
    }
}