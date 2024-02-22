#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Machine
{
    /// <summary>
    /// Отображение слота
    /// </summary>
    public class SlotView : MonoBehaviour, IDisposable
    {
        public Transform ContentTransform => _contentTransform;

        [SerializeField] private Text _title = null!;
        [SerializeField] private Transform _contentTransform = null!;
        [SerializeField] private VerticalLayoutGroup _verticalGroup = null!;
        [SerializeField] private ScrollRect _scroll = null!;
        
        private IItemFactory _itemFactory = null!;
        private ISlot _slot = null!;
        
        private readonly List<ItemView> _createdItems = new List<ItemView>();
        private IEnumerator? _runningAnimation;
        
        public void InitFactory(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public void Init(ISlot slot)
        {
            _slot = slot;

            CreateItems();

            _slot.OnStartAnimation += StartRotationAnimation;
            
            ChangeTitle(0);
        }

        private void CreateItems()
        {
            if (_createdItems.Count > _slot.NumberOfItems)
            {
                while (_createdItems.Count != _slot.NumberOfItems)
                {
                    var temp = _createdItems[0];
                    Destroy(temp);
                    _createdItems.RemoveAt(0);
                }
            }

            if (_createdItems.Count < _slot.NumberOfItems)
            {
                while (_createdItems.Count != _slot.NumberOfItems)
                {
                    var item = _itemFactory.Create();
                    _createdItems.Add(item);
                }
            }
            
            Debug.Assert(_createdItems.Count == _slot.NumberOfItems, "SlotView.CreateItems: The number of elements diverges.");

            var index = 0;
            foreach (var itemModel in _slot.ItemModels)
            {
                _createdItems[index].Init(itemModel);
                index++;
            }
        }

        private void StartRotationAnimation(TypeOfItem result)
        {
            if (_runningAnimation != null)
            {
                return;
            }

            _runningAnimation = RotationAnimationWithResult(result);
            StartCoroutine(_runningAnimation);
        }
        
        private IEnumerator RotationAnimationWithResult(TypeOfItem result)
        {
            if (_createdItems.Count == 0)
            {
                Debug.LogError("SlotView.RotationAnimationWithResult: createdItems is zero.");
                yield break;
            }

            yield return new WaitForEndOfFrame();

            var requiredIndex = _slot.ItemModels.ToList().FindIndex(item => item.Type == result);
            yield return RotationAnimation(requiredIndex + _createdItems.Count - 1);
            _scroll.content.localPosition = new Vector3(0, -100, 0);
            _runningAnimation = null;
        }
        
        private IEnumerator RotationAnimation(int numberOfRevolutions)
        {
            var selectedItemIndex = 0;
            var itemHeight = _createdItems[0].RectTransform.rect.height;
            var currentNumberOfRevolutions = 0;

            while (currentNumberOfRevolutions <= numberOfRevolutions)
            {
                yield return AnimationBetweenItems(0.07f, itemHeight);

                var item = _createdItems[selectedItemIndex];
                item.transform.SetAsLastSibling();
                selectedItemIndex = selectedItemIndex + 1 >= _createdItems.Count ? 0 : selectedItemIndex + 1;
                ChangeTitle(selectedItemIndex);
                
                _scroll.content.localPosition = Vector3.zero;
                currentNumberOfRevolutions++;
            }
        }
        
        private IEnumerator AnimationBetweenItems(float animationDuration, float itemHeight)
        {
            if (_createdItems.Count == 0)
            {
                yield break;
            }

            var progress = 0.0f;
            var minY = 0.0f;
            var maxY = itemHeight + _verticalGroup.spacing;

            var time = 0.0f;

            while (progress <= 1.0f)
            {
                progress = time / animationDuration;
                var currentY = Mathf.Lerp(minY, maxY, progress);

                _scroll.content.localPosition = new Vector3(0, currentY, 0);
                yield return null;

                time += Time.deltaTime;
            }

        }

        private void ChangeTitle(int selectedItemIndex)
        {
            _title.text = _slot.ItemModels.ToArray()[selectedItemIndex].Title;
        }
        
        private void OnDestroy()
        {
            Dispose();
        }

        public void Dispose()
        {
            _slot.OnStartAnimation -= StartRotationAnimation;
        }
    }
}