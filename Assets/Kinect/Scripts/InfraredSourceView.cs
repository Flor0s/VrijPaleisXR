using UnityEngine;
using System.Collections;

public class InfraredSourceView : MonoBehaviour 
{
    public GameObject InfraredSourceManager;
    private InfraredSourceManager _InfraredManager;
    Renderer render;
    
    void Start () 
    {
        render = gameObject.GetComponent<Renderer>();
        render.material.SetTextureScale("_MainTex", new Vector2(-1, 1));
    }
    
    void Update()
    {
        if (InfraredSourceManager == null)
        {
            return;
        }
        
        _InfraredManager = InfraredSourceManager.GetComponent<InfraredSourceManager>();
        if (_InfraredManager == null)
        {
            return;
        }
    
        render.material.mainTexture = _InfraredManager.GetInfraredTexture();
    }
}
