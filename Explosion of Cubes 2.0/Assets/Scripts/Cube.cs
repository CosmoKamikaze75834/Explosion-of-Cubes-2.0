using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _maxChance = 100f;

    public float MaxChance => _maxChance;

    public void SetChance(float newChance)
    {
        _maxChance = newChance;
    }
}