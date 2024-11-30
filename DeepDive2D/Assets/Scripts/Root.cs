using BuildingScripts;
using GroundScripts;
using PlayerScripts;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Ground ground;
    [SerializeField] private Player player;
    [SerializeField] private Lazer lazer;
    
    private void Awake()
    {
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
