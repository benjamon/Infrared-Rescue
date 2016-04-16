using UnityEngine;

[ExecuteInEditMode]
public class CustomImageEffect : MonoBehaviour
{
    public Material EffectMaterial;
    RenderTexture temp;

    void Start()
    {
        //temp = new RenderTexture(Screen.width, Screen.height, 24);
    }

    void Update()
    {
        //EffectMaterial.SetFloat("Magnitude", Random.Range(0F, .1F));
        
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (EffectMaterial != null)
            Graphics.Blit(src, dst, EffectMaterial);
    }
}

