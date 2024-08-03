using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAdjust : MonoBehaviour
{
    public Canvas canvas;
    public float determine;

    private void Update()
    {
        transform.position = new Vector3(0,16,-canvas.GetComponent<RectTransform>().rect.height / determine);
    }
}
