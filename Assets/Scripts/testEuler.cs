using UnityEngine;
using System.Collections;

public class testEuler : MonoBehaviour
{
    private float xRotation = 0f;
    private float yRotation = 0f;

    // Use this for initialization
    void Start()
    {
        Debug.Log(transform.eulerAngles);
        Debug.Log(string.Format("{0},{1},{2}", transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));

        // 设置为无旋转（rotation是一个四元数）
        //transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        // 欧拉角：欧拉角的使用只能整体赋值，不能单独修改某一轴，详情看Unity说明
        xRotation += Input.GetAxis("Vertical");
        yRotation += Input.GetAxis("Horizontal");
        Debug.Log(xRotation + "," + yRotation);
        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
        Debug.Log(transform.eulerAngles);

        // 四元数
        //transform.rotation = new Quaternion();
    }
}
