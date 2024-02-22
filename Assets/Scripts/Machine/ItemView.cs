#nullable enable
using UnityEngine;
using UnityEngine.UI;

namespace Machine
{
    /// <summary>
    /// Отображение предмета, который может выпасть игроку
    /// </summary>
    public class ItemView : MonoBehaviour
    {
        public RectTransform RectTransform => (RectTransform)transform;
        
        [SerializeField] private Image _icon = null!;
        
        public void Init(IItem item)
        {
            _icon.sprite = item.Icon;
        }
    }
}