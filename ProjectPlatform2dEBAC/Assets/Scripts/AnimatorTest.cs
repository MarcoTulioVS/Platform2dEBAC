using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator anim;

    public string triggerToPlay = "fly";

    private void OnValidate()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger(triggerToPlay);
        }
    }
}
