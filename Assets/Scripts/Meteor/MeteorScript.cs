using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    /// <summary>
    /// 半径
    /// </summary>
    public float radius;
    /// <summary>
    /// 坚硬度
    /// </summary>
    public float flintiness;

    /// <summary>
    /// 下落速度
    /// </summary>
    public float speed;

    /// <summary>
    /// 旋转速度
    /// </summary>
    public float rotationalSpeed;

    /// <summary>
    /// 是否已经被碰到过,一次滑动操作中，当小球被碰到过一次后为false，需要玩家抬起手指方可再次滑动。
    /// </summary>
    public bool canDrag;

    public bool isDie;

    // 父类传进的相关值，根据相关值随机实例,实例传回给父类管理
    public MeteoritePointScript meteoritePointScript = new MeteoritePointScript();

    void Awake()
    {
        isDie = false;
        InitPosition(true);
        InitData();
    }

    // 初始化位置, 简单模式是正太分布，非简单模式是全随机
    private void InitPosition(bool eazy)
    {
        float temp;
        do
        {
            // 随机一个x坐标
            if (eazy)
                temp = (Tools.Random() + 2) * 270;
            else
                temp = (Random.Range(0, 1080)) - 270;
        } while (temp <= 0 || temp >= 1080);
        transform.position += new Vector3(temp/540 - 1, 0, 0);
    }

    // 随机数据
    private void RandomData()
    {
        radius = Tools.Random() + 3; // 1 ~ 5
        flintiness = Tools.Random() + 2 + meteoritePointScript.flintiness;  // 1.5 + flintiness
        speed = Tools.Random() + 2 + meteoritePointScript.speed;  // 1.5 + speed
        rotationalSpeed = Tools.Random() + 2;  // 0 ~ 4 

    }

    // 设置陨石数值
    private void InitData()
    {
        RandomData();

        // TODO
        transform.localScale = new Vector3(1 + radius, 1 + radius, 1);
        transform.GetComponent<Rigidbody2D>().gravityScale += speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "wall")
        {
            meteoritePointScript.RemoveMeteor(gameObject);
        }

        if (isDie == true)
        {
            meteoritePointScript.RemoveMeteor(gameObject);
        }
    }
}
