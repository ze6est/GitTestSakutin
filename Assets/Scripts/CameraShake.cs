using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Animator _cameraShake;

    public void Shake()
    {
        _cameraShake.SetTrigger("shake");
    }
}
