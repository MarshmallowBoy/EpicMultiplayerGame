
public class EquipmentSlot : InventorySlot
{
    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        gameObject.name = EquipmentType.ToString() + "Slot";
    }
}