using BuildingScripts;
using GroundScripts;
using PlayerScripts;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Ground ground;
    [SerializeField] private Player player;
    [SerializeField] private Lazer lazer;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private InventoryScripts.Inventory inventory;
    
    private void Awake()
    {
        inventory.Init();
        playerUI.Init();
        player.Init();
        ground.Init();
        lazer.Init();
    }

    private void Update()
    {
        ground.UpdateGround();
        player.UpdatePlayer();
    }
}
