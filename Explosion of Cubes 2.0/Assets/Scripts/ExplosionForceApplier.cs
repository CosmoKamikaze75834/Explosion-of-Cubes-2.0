using System.Collections.Generic;
using UnityEngine;

public class ExplosionForceApplier: MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _baseExplosionForce;
    [SerializeField] private float _baseExplosionRadius;

    public void Explode(Cube cube)
    {
        float size = cube.transform.localScale.x;

        float cubeExplosionRadius = _baseExplosionRadius / size;
        float cubeExplosionForce = _baseExplosionForce / size;

        if (cube.TryGetComponent(out Rigidbody component))
        {
            List<Rigidbody> objects = GetObjectsRadius(cube, component, cubeExplosionRadius);

            foreach (Rigidbody child in objects)
            {
                child.AddExplosionForce(cubeExplosionForce, cube.transform.position, cubeExplosionRadius);
            }

            _spawner.DestroyObject(cube);
        }
    }

    private List<Rigidbody> GetObjectsRadius(Cube cube, Rigidbody excludedObject, float explosionRadius)
    {
        Vector3 explosionPosition = cube.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null && collider.attachedRigidbody != excludedObject && collider.TryGetComponent<Cube>(out _))
            {
                cubes.Add(collider.attachedRigidbody);
            }
        }

        return cubes;
    }
}