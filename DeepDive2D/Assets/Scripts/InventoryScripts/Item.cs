using UnityEngine;

namespace InventoryScripts
{
    [CreateAssetMenu(menuName = "InventoryItem", fileName = "Item")]
    public class Item : ScriptableObject
    {
        public string name;
        public MaterialType type;
        public Sprite itemSprite;
        
        [Header("Values")]
        public int mass;
        public int cost;
    }

    public enum MaterialType
    {
        Resource,
        Meterial,
        Collectable,
        Bon,
        QuestObject
    }
}
