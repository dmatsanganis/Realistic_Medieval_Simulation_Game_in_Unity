using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimalStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//intialize animator 
        Animator anim = GetComponent<Animator>();
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
		//play a random animator
        anim.Play(state.fullPathHash, -1, Random.Range(0f, 58f));
    }
}
