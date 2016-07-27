using UnityEngine;
using System.Collections;

public class TestTransform : MonoBehaviour
{
    public float snapvalue = 1f;

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
        //
        float xOffset = Input.GetAxis("Horizontal") * snapvalue;
        float yOffset = Input.GetAxis("Vertical") * snapvalue;

        if (Input.GetMouseButton(0))
        {
            // 计算偏移旋转角          
            Vector3 roateAngle = new Vector3(yOffset, xOffset, 0);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                // 1、欧拉角用法:Unity建议不要递增欧拉角
                switch (this.enumCoordinateType)
                {
                    case CoordinateType.World:
                        // 世界欧拉角：绝对（相对于世界中心的坐标系）
                        this.transform.eulerAngles += roateAngle;
                        break;
                    case CoordinateType.Local:
                        // 本地欧拉角：相对（相对于父节点的坐标系）
                        this.transform.localEulerAngles += roateAngle;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Quaternion rotation;
                // 2、四元数用法(欧拉角转换为四元数)
                switch (this.enumCoordinateType)
                {
                    case CoordinateType.World:
                        // 绝对（相对于世界中心的坐标系）    
                        rotation = Quaternion.Euler(this.transform.eulerAngles + roateAngle);
                        this.transform.rotation = rotation;
                        break;
                    case CoordinateType.Local:
                        // 相对（相对于父节点的坐标系）
                        rotation = Quaternion.Euler(this.transform.localEulerAngles + roateAngle);
                        this.transform.localRotation = rotation;
                        break;
                    default:
                        break;
                }
            }
        }
        else if (Input.GetMouseButton(1))
        {
            // 缩放     
            Vector3 scale = new Vector3(xOffset, yOffset, 0);

            switch (this.enumCoordinateType)
            {
                case CoordinateType.World:
                    // 世界缩放（有损--相对于世界节点）
                    // this.transform.lossyScale; // 只读的(是通过递归父节点缩放后得到的一个缩放值)
                    break;
                case CoordinateType.Local:
                    // 相对缩放（相对于父节点的缩放）
                    this.transform.localScale += scale;
                    break;
                default:
                    break;
            }
        }
        else
        {
            // 平移
            Vector3 pos = new Vector3(xOffset, yOffset, 0);

            switch (this.enumCoordinateType)
            {
                case CoordinateType.World:
                    // 世界坐标（绝对坐标）
                    this.transform.position += pos;
                    break;
                case CoordinateType.Local:
                    // 相对坐标（相对于父节点坐标系）
                    this.transform.localPosition += pos;
                    break;
                default:
                    break;
            }
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
        if (GUI.Button(new Rect(800, 50, 100, 20), "Reset"))
        {
            this.transform.localPosition = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
            //this.transform.localEulerAngles = Vector3.zero;
            this.transform.localScale = Vector3.one;
        }

    }
}
