using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    //[SerializeField]
    //private CameraControlerScript _keyActionParentObject;
    // Start is called before the first frame update
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルを追尾
        if (Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger("turnRight");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            _animator.SetTrigger("turnLeft");
        }
    }
}
