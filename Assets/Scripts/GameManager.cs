using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg.material.mainTextureOffset = bg.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
    }
}
