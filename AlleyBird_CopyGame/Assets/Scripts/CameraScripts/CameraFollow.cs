using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    const float cameraOffset = -1f;

    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y, cameraOffset);
    }
}
