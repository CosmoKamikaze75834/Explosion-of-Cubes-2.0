using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ColorChange _color;

    private float _multeplier = 0.5f;
    private float _currentChance = 2;

    public Cube Spawn(Vector3 position, Vector3 parentScale, float parentChance)
    {
        Cube child = Instantiate(_cubePrefab, position, Quaternion.identity);

        child.transform.localScale = parentScale * _multeplier;

        if (!child.TryGetComponent(out Cube cubeScript))
        {
            return null;
        }

        cubeScript.SetChance(parentChance / _currentChance);

        _color.ApplyRandomColor(child);

        return child;
    }

    public void DestroyObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}