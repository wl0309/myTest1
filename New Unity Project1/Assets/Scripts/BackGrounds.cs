using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backGrounds;
    public float fparallax = 0.4f;//float型必须加f
    public float layerFraction = 0.5f;
    public float fSmooth = 5f;
    Transform cam;
    Vector3 prevoiusCamPos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    private void Start()
    {
        prevoiusCamPos = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        float fParallaxX = (prevoiusCamPos.x - cam.position.x) * fparallax;
        float fParallaxY = (prevoiusCamPos.y - cam.position.y) * fparallax;
        for(int i=0;i<backGrounds.Length; i++)
        {
            float fNewX = backGrounds[i].position.x + fParallaxX * (1 + i*layerFraction );
            float fNewY = backGrounds[i].position.y + fParallaxY * (1 + i * layerFraction);
            Vector3 newPos = new Vector3(fNewX,fNewY , backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, newPos, Time.deltaTime * fSmooth);
        }
        prevoiusCamPos = cam.position;
    }
}
