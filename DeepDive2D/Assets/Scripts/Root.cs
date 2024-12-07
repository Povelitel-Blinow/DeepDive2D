using BuildingScripts;
using CargoShipScripts;
using GroundScripts;
using InventoryScripts;
using PlayerScripts;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Ground ground;
    [SerializeField] private Player player;
    [SerializeField] private Lazer lazer;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private Inventory inventory;
    [SerializeField] private CargoShipHandler cargo;
    [SerializeField] private MineBuildHandler mineBuildHandler;

    public static Root Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            inventory.Init();
            playerUI.Init();
            player.Init();
            ground.Init();
            lazer.Init();
            cargo.Init();
            mineBuildHandler.Init();
            return;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        ground.UpdateGround();
        player.UpdatePlayer();
    }
}
