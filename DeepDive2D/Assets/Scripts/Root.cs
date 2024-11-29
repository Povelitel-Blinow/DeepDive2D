using System;
using GroundScripts;
using PlayerScripts;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Ground ground;
    [SerializeField] private Player player;
    
    private void Awake()
    {
        player.Init();
        ground.Init();
    }

    private void Update()
    {
        ground.UpdateGround();
        player.UpdatePlayer();
    }
}
