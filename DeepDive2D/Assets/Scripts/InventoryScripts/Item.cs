using UnityEngine;

namespace InventoryScripts
{
    [CreateAssetMenu(menuName = "InventoryItem", fileName = "Item")]
    public class Item : ScriptableObject
    {
        public MaterialType type;
        public Sprite itemSprite;
    }

    public enum MaterialType
    {
        C,
        Fe,
        Ni,
        Mg,
        Cu
    }
}
