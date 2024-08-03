using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    Slider slider;
    public PlayerBehaviour playerBehaviour;

    // Update is called once per frame
    void Update()
    {
        slider.value = playerBehaviour.energy * 0.2f;
    }
}
