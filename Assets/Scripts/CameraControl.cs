using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    private const float lowPassFilterFactor = 0.2f;

    // Use this for initialization
    void Start()
    {
        Input.gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation = Quaternion.Slerp(transform.rotation, Input.gyro.attitude, lowPassFilterFactor);

        Vector3 euler = new Vector3(0, Input.gyro.attitude.eulerAngles.y, 0);
        this.transform.eulerAngles = euler;
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(30, 30, 500, 20), string.Format("{0},{1},{2}", Input.gyro.attitude.x, Input.gyro.attitude.y, Input.gyro.attitude.z));
        GUI.Label(new Rect(30, 60, 500, 20), string.Format("{0},{1},{2}", Input.gyro.attitude.eulerAngles.x, Input.gyro.attitude.eulerAngles.y, Input.gyro.attitude.eulerAngles.z));
    }
}
