using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrollingScript : MonoBehaviour
{
    //a reference to the mesh for this object, where the material lives
    public MeshRenderer textureMesh;
    //the rate at which the tiling will change every second
    public Vector2 tilingspeed;
    //a private reference to the material we're offsetting, so we dont have to 
    //get it everyframe
    private Material mat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //we cache the material 0f the mesh 
        mat = textureMesh.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //set the main texture and normal map offset to be its current value
        //+ the tiling speed normalized, that way we can continuously increase it.
        
        mat.SetTextureOffset("_MainTex",
            mat.GetTextureOffset("_MainTex") + tilingspeed * Time.deltaTime
            );
        mat.SetTextureOffset("_DetailAlbedoMap",
            mat.GetTextureOffset("_DetailAlbedoMap") + tilingspeed * Time.deltaTime
            );
    }
}
