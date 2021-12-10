using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlerScript : MonoBehaviour
{
    private GameObject pintTarget;       //ターゲット格納用
    [SerializeField]
    private Camera cameraFOV = null;
    float wantRotation;
    float wantFOV;
    float turnTime = 0.1f;
    [SerializeField]
    int zoomCnt = 2;

    Quaternion want;
    // Start is called before the first frame update
    void Start()
    {
        pintTarget = GameObject.Find("CameraControler");
        wantRotation = this.gameObject.transform.rotation.eulerAngles.y;
        wantFOV = 50f;

    }

    // Update is called once per frame
    void Update()
    {
        //指定キー２個でアングルをぐるぐる90°ずつ切り替える
        //カーソルを追尾
        if (Input.GetKeyDown(KeyCode.J))
        {
            wantRotation += 90f;
            //transform.RotateAround(pintTarget.transform.position, Vector3.up, -0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            wantRotation -= 90f;
            //transform.RotateAround(pintTarget.transform.position, Vector3.up, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (!(zoomCnt < 1))
            {
                wantFOV -= 20f;
                zoomCnt -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (!(zoomCnt > 2))
            {
                wantFOV += 20f;
                zoomCnt += 1;
            }
        }

        want = Quaternion.AngleAxis(wantRotation, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, want, Time.deltaTime / turnTime);
        //cameraFOV.fieldOfView = wantFOV;
        cameraFOV.fieldOfView = Mathf.Lerp(cameraFOV.fieldOfView, wantFOV, Time.deltaTime / turnTime);

    }
}
