using System;
using System.Collections;
using UnityEngine;

public class DiceFaceCheck : MonoBehaviour
{
    public static Action<int> OnDiceStop;

    Vector3 vlocity;
    bool waitFORMe;

    int CalcSideUp()
    {
        float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
        if (dotFwd > 0.99f) return 50;
        if (dotFwd < -0.99f) return 30;

        float dotRight = Vector3.Dot(transform.right, Vector3.up);
        if (dotRight > 0.99f) return 40;
        if (dotRight < -0.99f) return 15;

        float dotUp = Vector3.Dot(transform.up, Vector3.up);
        if (dotUp > 0.99f) return 20;
        if (dotUp < -0.99f) return 60;

        return 0;
    }
    private void FixedUpdate()
    {
        vlocity = DiceRoll.diceVelocity;
    }
    void Update()
    {
        if (vlocity == Vector3.zero && !waitFORMe)
        {
            StartCoroutine(WaitFORMe());
        }
    }

    IEnumerator WaitFORMe()
    {
        waitFORMe = true;
        yield return new WaitForSeconds(1f);
        if (vlocity == Vector3.zero)
        {
            DiceStopped();
        } 
        else
        {
            waitFORMe = false;
        }
    }

    void DiceStopped()
    {
        int side = CalcSideUp();
        OnDiceStop?.Invoke(side);
        Destroy(gameObject);
    }
}
