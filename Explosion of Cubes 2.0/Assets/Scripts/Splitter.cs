using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private RaycastLaunch _raycast;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionForceApplier _force;

    private int _minCubs = 2;
    private int _maxCubs = 6;
    private float _maxChance = 100f;
    private float _minChance = 0f;
    private float _explosionForce = 500f;

    public void Start()
    {
        _input.MouseClicked += OnScreenClick;
    }

    private void OnScreenClick(Vector2 screenPos)
    {
        if(_raycast.TryGetClickedObject(screenPos, out GameObject hitObgect))
        {
            if(hitObgect.TryGetComponent(out Cube cube))
            {
                HandleCubeClick(cube);
            }
        }
    }

    private void HandleCubeClick(Cube cube)
    {
        float random = Random.Range(_minChance, _maxChance);

        if (random <= cube.MaxChance)
        {
            List<Rigidbody> children = new List<Rigidbody>();

            int count = Random.Range(_minCubs, _maxCubs);

            SpawnObject(count, cube, children);

            _force.Apply(children, cube.transform.position, _explosionForce);
        }

        _spawner.DestroyObject(cube);
    }

    private void SpawnObject(int count, Cube cube, List<Rigidbody> cubes)
    {
        for (int i = 0; i < count; i++)
        {
            Cube child = _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.MaxChance);
            
            if(child.TryGetComponent(out Rigidbody rigidbody))
            {
                cubes.Add(rigidbody);
            }
        }
    }
}