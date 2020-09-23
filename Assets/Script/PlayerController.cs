using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().Translate(new Vector3(-0.05f,0,0));
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().Translate(new Vector3(0.05f, 0, 0));
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            PlayerAnimation.SetBool("Walking",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnimation.SetBool("Walking",false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            PlayerAnimation.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnimation.SetBool("Walking", false);
        }
    }
}
