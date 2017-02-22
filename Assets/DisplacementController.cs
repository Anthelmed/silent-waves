using UnityEngine;
using System.Collections;

public class DisplacementController : MonoBehaviour {

    public int pixWidth;
    public int pixHeight;
    public float xOrg;
    public float yOrg;
    public float scale = 1.0F;
    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;
    private Shader shader;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Waves");
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
    }

    void Update()
    {
        xOrg += Time.deltaTime * 4;
        yOrg += Time.deltaTime * 4;
        CalcNoise();
        rend.material.SetTexture("_NoiseMap", noiseTex);
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

    void CalcNoise()
    {
        float y = 0.0F;
        while (y < noiseTex.height)
        {
            float x = 0.0F;
            while (x < noiseTex.width)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }
}
