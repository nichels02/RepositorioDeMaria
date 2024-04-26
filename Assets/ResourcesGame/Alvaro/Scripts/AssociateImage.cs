using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssociateImage : MonoBehaviour
{
    public float scaleFactor = 2.5f;
    public SpriteRenderer image;
    public Material mat;
    public GameObject display;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = new Vector3((image.size.x/image.size.y)* scaleFactor, scaleFactor, scaleFactor);
        this.transform.localScale = scale;
        var x = display.GetComponent<MeshRenderer>();
        x.material = mat;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
