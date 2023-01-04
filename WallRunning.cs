using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    //Hi
    public Movement moveScript;
    public Transform CamTrans;
    //public Camera cam;
    private IEnumerator coroutine;
    Quaternion targetm = Quaternion.Euler(0, 0, -18);
    Quaternion targetp = Quaternion.Euler(0, 0, 18);
    public Transform wallt;
    public Transform playrt;
    public bool left;
    public bool right;
    public float yAxisTarget;
    //public Transform rayT;
    bool exmp;
    float def;
    Vector3 plyrtymi = new Vector3();

    private void FixedUpdate()
    {
        int LayerMaskInt = 1 << 8;

        RaycastHit hit;
        float a = playrt.position.y;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 2f, LayerMaskInt))
        {
            if (exmp == false)
            {
                //Debug.Log("fuck");
                moveScript.canjump1 = true;
                a = playrt.position.y;
                exmp = true;
            }
            if (exmp == true)
            {
            //    moveScript.canjump1 = false;
            }
            if (playrt.position.y > a + 1)
            {
                def = playrt.position.y - a;
                for (int i = 0; i < def*10 ; i++)
                {
                    plyrtymi = new(playrt.position.x, playrt.position.y - 0.1f, playrt.position.z);
                    playrt.position = plyrtymi;
                }
            }
            CamTrans.localEulerAngles = new(0, 0, 24 * (2f - hit.distance));
            moveScript.IsWall = true;
            right = true;
            moveScript.IsWallJ = true;
            yAxisTarget = hit.transform.rotation.y; 
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 2f, LayerMaskInt))
        {
            if (exmp == false)
            {
                moveScript.canjump1 = true;
                a = playrt.position.y;
                exmp = true;
            }
            if (exmp == true)
            {
             //   moveScript.canjump1 = false;
            }
            if (playrt.position.y > a + 1)
            {
                def = playrt.position.y - a;
                for (int i = 0; i < def * 10; i++)
                {
                    plyrtymi = new(playrt.position.x, playrt.position.y - 0.1f, playrt.position.z);
                    playrt.position = plyrtymi;
                }
            }
            CamTrans.localEulerAngles = new(0, 0, -24 * (2f - hit.distance));
            moveScript.IsWall = true;
            left = true;
            moveScript.IsWallJ = true;
            yAxisTarget = hit.transform.localEulerAngles.y;

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 2f, LayerMaskInt) == false && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 2f, LayerMaskInt) == false)
        {
            exmp = false;
            right = false;
            left = false;
            CamTrans.localEulerAngles = new(0, 0, 0);
            moveScript.IsWall = false;
          //  coroutine = wallrunJump(0.5f);
           // StartCoroutine(coroutine);
        }



        if (right)
        {
            //Debug.Log("wallsR");
        }
        if (left)
        {
            //Debug.Log("wallsL");
        }
        //Debug.Log("IsWall : " + moveScript.IsWall);
        //Debug.Log("IsWallJ : " + moveScript.IsWallJ);
    }
    IEnumerator wallrunJump(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
        if (left == true || right == true)
            { 
                moveScript.IsWallJ = true;
            }
        else
            {
                moveScript.IsWallJ = false;
            }
        }

    }
}
