using UnityEngine;

public class RaycastLaunch : MonoBehaviour
{
    public bool TryGetClickedObject(Vector2 screenPosition, out GameObject hitObject)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hitObject = hit.collider.gameObject;

            return true;
        }

        hitObject = null;
        return false;
    }
}