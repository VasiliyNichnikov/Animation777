#nullable enable
using UnityEngine;

namespace Machine
{
    /// <summary>
    /// Предмет, который может выпасть игроку
    /// </summary>
    public interface IItem
    {
        Sprite Icon { get; }

        string Title { get; }

        TypeOfItem Type { get; }
    }
}