using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    [SerializeField] float liveTime = 4f;
    float curTime = 0f;

    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= liveTime)
        {
            Destroy(gameObject);
        }
    }
}
