using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置を追尾する形だがサイド側のオブジェクトだと少し向きがずれてしまう
        //カメラの位置+自分のXZを足して
        pos = Camera.main.transform.position;
        pos.x += this.transform.position.x;
        pos.z += this.transform.position.z;
        pos.y = transform.position.y;
        transform.LookAt(pos);
    }
}
