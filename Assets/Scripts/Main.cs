#nullable enable
using Algorithm;
using Data;
using Factory;
using Machine;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RectTransform _machineParent = null!;
    
    [SerializeField] private ItemView _itemPrefab = null!;
    [SerializeField] private SlotView _slotPrefab = null!;
    [SerializeField] private MachineView _machinePrefab = null!;
    
    [SerializeField] private MachineSettings _machineSettings = null!;

    private IMachineManager _machineManager = null!;

    /// <summary>
    /// Called from unity
    /// </summary>
    public void ReRoll()
    {
        _machineManager.Run();
    }
    
    private void Awake()
    {
        // Сначала инитим завод
        var machineFactory = new MachineFactory(_machinePrefab, 
            _slotPrefab, 
            _itemPrefab, 
            _machineParent);
        // Затем манагер
        _machineManager = new MachineManager(_machineSettings, machineFactory, new RandomItemAlgorithmBlank());
    }

    private void Start()
    {
        _machineManager.Init();
    }
}
