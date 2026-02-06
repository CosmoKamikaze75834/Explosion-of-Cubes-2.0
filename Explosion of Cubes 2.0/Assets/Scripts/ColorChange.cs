using UnityEngine;

public class ColorChange:MonoBehaviour
{
    public void ApplyRandomColor(Cube cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        if(renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}