using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class rotateExample : MonoBehaviour
{
    public float modifier;
    public float time;
    public RectTransform myRT;
    // Start is called before the first frame update
    void Start()
    {
        myRT.DOLocalRotate(Vector3.one * modifier, time, RotateMode.Fast);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
