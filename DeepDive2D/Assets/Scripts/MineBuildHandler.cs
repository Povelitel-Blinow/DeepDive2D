using UnityEngine;

public class MineBuildHandler : MonoBehaviour
{
    [SerializeField] private int[] buildPrices;

    private int currentBuiltIndex = 0;

    public static MineBuildHandler Instance { get; private set; }

    public void Init()
    {
        Instance = this;
    }

    public void Build()
    {
        currentBuiltIndex += 1;
    }

    public int GetPrice()
    {
        return buildPrices[Mathf.Clamp(currentBuiltIndex, 0, buildPrices.Length - 1)];
    }
}
