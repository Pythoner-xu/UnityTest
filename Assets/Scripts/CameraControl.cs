using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 研究手机陀螺仪
/// </summary>
public class CameraControl : MonoBehaviour
{

    #region 暴露给Editor的变量
    public Text ui_LogText;
    public InputField ui_InputText;
    #endregion

    private Gyroscope gyro;

    // Use this for initialization
    void Start()
    {
        // 获取设备陀螺仪
        gyro = Input.gyro;

        // 获取设备姿态角（这里是一个四元数）
        Quaternion quaternion = gyro.attitude;

        // 陀螺仪是否启用(可设置)
        bool gyroStatus = gyro.enabled;

        // 获得设备参考系下，重力加速度向量
        Vector3 gravity = gyro.gravity;

        // 获得设备陀螺仪测量的旋转速率
        Vector3 rotationRate = gyro.rotationRate;

        // 获得设备陀螺仪测量的无偏移旋转速率
        Vector3 rotationRateUnbiased = gyro.rotationRateUnbiased;

        // 设置陀螺仪更新的间隔时间（可设置）
        float updateInterval = gyro.updateInterval;

        // 获得用户施加给设备的加速度
        Vector3 userAcceleration = gyro.userAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, gyro.attitude, 0.2f);
    }

    void OnGUI()
    {      
        string str = string.Format("是否开启陀螺仪:{0},\n 陀螺仪姿态角四元数:{1},\n 重力加速度:{2},\n 旋转速率:{3},\n 无偏移旋转速率:{4},\n 陀螺仪更新间隔:{5},\n 设备移动加速度:{6},\n",
            gyro.enabled,
            gyro.attitude,
            gyro.gravity,
            gyro.rotationRate,
            gyro.rotationRateUnbiased,
            gyro.updateInterval,
            gyro.userAcceleration);


        str += string.Format("陀螺仪欧拉角：{0}", gyro.attitude.eulerAngles);

        str += string.Format("相机欧拉角：{0}", this.transform.rotation);

        GUIStyle style = new GUIStyle();
        style.fontSize = 25;
        style.normal.textColor = Color.yellow;
        GUI.Label(new Rect(30, 30, 400, 600), str, style);


        //if (GUI.Button(new Rect(30, 100, 100, 20), "开启/关闭陀螺仪"))
        //{
        //    Input.gyro.enabled = !Input.gyro.enabled;
        //}
    }

    private Quaternion ConvertRotation(Quaternion q)
    {

        return new Quaternion(q.x, q.y, -q.z, -q.w);

    }


    public void OpenToggle()
    {
        Input.gyro.enabled = !Input.gyro.enabled;
        this.ui_LogText.text += Input.gyro.enabled ? "开启陀螺仪" : "关闭陀螺仪";
    }

    public void SetGryoUpdateInterVal()
    {
        if (this.ui_InputText.text != "")
        {
            Input.gyro.updateInterval = int.Parse(this.ui_InputText.text);
            this.ui_LogText.text += "设置陀螺仪更新间隔：" + Input.gyro.updateInterval;
        }
    }

    public void Reset()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
