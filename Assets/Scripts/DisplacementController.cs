using UnityEngine;
using System.Collections;

public class DisplacementController : MonoBehaviour {

    private Renderer rend;
    private Shader shader;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Waves");
    }

    public float getDisplacementScale()
    {
        return rend.material.GetFloat("_DisplacementScale");
    }

    public void setDisplacementScale(float newDisplacementScale)
    {
        float displacementScale = (newDisplacementScale < 1) ? newDisplacementScale : 1;
        rend.material.SetFloat("_DisplacementScale", displacementScale);
    }
}
