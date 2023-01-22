using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private void Start()
    {

    }

    public void SetDeadFace()
    {
        GetComponent<Animator>().SetBool("happy", true);
    }

}
