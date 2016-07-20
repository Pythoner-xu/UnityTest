using UnityEngine;
using System.Collections;

public class TestTransform : MonoBehaviour
{
    public float snapvalue = 1f;
    private float xRotation = 0;
    private float yRotation = 0;

    public enum CoordinateType
    {
        World,
        Local
    }
    // 
    public CoordinateType enumCoordinateType = CoordinateType.Local;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 欧拉角用法:Unity建议不要递增欧拉角
        xRotation += Input.GetAxis("Horizontal") * snapvalue;
        yRotation += Input.GetAxis("Vertical") * snapvalue;

        //xRotation = xRotation % 360;
        //yRotation = yRotation % 360;

        switch (enumCoordinateType)
        {
            case CoordinateType.World:
                // 世界欧拉角：绝对（相对于世界中心的坐标系）
                this.transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
                break;
            case CoordinateType.Local:
                // 本地欧拉角：相对（相对于父节点的坐标系）
                this.transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
                break;
            default:
                break;
        }
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        string str = "World和Local只有在有父节点的时候才有区别，如果没有父节点，这两个值是一致的\n";
        GUI.Label(new Rect(30, 10, 800, 600), str);

        GUI.color = Color.yellow;


        str = string.Format("Transform:{0}\n\n", this.transform);

        str += string.Format("World坐标-position：{0}\n", this.transform.position);
        str += string.Format("Local坐标-localPosition：{0}\n", this.transform.localPosition);
        if (this.transform.parent != null)
        {
            str += string.Format("父节点坐标：{0}\n\n", this.transform.parent.position);
        }


        str += string.Format("World旋转欧拉角-eulerAngles：{0}\n", this.transform.eulerAngles);
        str += string.Format("Local旋转欧拉角-localEulerAngles：{0}\n", this.transform.localEulerAngles);
        if (this.transform.parent != null)
        {
            str += string.Format("父节点旋转欧拉角：{0}\n", this.transform.parent.eulerAngles);
        }


        str += string.Format("World旋转四元数-rotation：{0}\n", this.transform.rotation);
        str += string.Format("Local旋转四元数-localRotation:{0}\n", this.transform.localRotation);
        if (this.transform.parent != null)
        {
            str += string.Format("父节点旋转四元数：{0}\n\n", this.transform.parent.rotation);
        }


        str += string.Format("有损缩放-lossyScale：{0}\n", this.transform.lossyScale);
        str += string.Format("Local缩放-localScale：{0}\n", this.transform.localScale);
        if (this.transform.parent != null)
        {
            str += string.Format("父节点缩放：{0}\n", this.transform.parent.lossyScale);
        }

        str += string.Format("x轴axis-x：{0},y轴axis-y：{1},z轴axis-z：{2}\n", this.transform.right, this.transform.up, this.transform.forward);

        str += string.Format("父节点parent:{0}\n", this.transform.parent);

        str += string.Format("顶级父节点root:{0}\n", this.transform.root);

        str += string.Format("子节点个数childCount:{0}\n", this.transform.childCount);

        str += string.Format("World>>Local的矩阵：\n{0}\n", this.transform.worldToLocalMatrix);

        str += string.Format("Local>>World的矩阵：\n{0}\n", this.transform.localToWorldMatrix);


        GUI.Label(new Rect(30, 30, 800, 800), str);


        GUI.color = Color.green;
        GUI.Label(new Rect(800, 30, 300, 800), string.Format("{0}, {1}", this.xRotation, this.yRotation));
        if (GUI.Button(new Rect(800, 50, 100, 20), "Reset"))
        {
            this.xRotation = 0;
            this.yRotation = 0;
        }

    }
}
