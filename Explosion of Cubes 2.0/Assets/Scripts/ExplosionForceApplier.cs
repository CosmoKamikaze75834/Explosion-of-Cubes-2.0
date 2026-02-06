using System.Collections.Generic;
using UnityEngine;

public class ExplosionForceApplier: MonoBehaviour
{ 
    private int _explosionRadius = 0;

    public void Apply(List<Rigidbody> children, Vector3 explosionCenter, float _explosionForce)
    {
        foreach (var child in children)
        {
            if(child != null)
            {
                child.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
            }
        }
    }
}