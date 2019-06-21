using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    public User user;  // 加载游戏难度、道具等级等
    public MeteoritePointScript meteoritePointScript;  // 陨石生成的管理类
    private Camera _currentCamera;

    void Awake()
    {
        user = UserProtobuf.Instance.UserDeserialization();  // 反序列化，读取User
        meteoritePointScript = GameObject.Find("MeteoritePoint").GetComponent<MeteoritePointScript>();
        _currentCamera = Camera.main;
    }

    void Update()
    {
        input();
    }

    Vector2 firstPos;
    Vector2 secondPos;
    private void input()
    {
        // mouse
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
            foreach (GameObject item in meteoritePointScript.Meteors)
            {
                item.GetComponent<MeteorScript>().canDrag = true;
            }
            /* 拖拽逻辑，放在这里只能拖拽一个，放在下面可以拖拽多个 */
            List<GameObject> items = AttackMeteorites(_currentCamera.ScreenToWorldPoint(Input.mousePosition), user.Scope, user.Damage);  // 攻击陨石
            Vector3 glideDir = secondPos - firstPos;  // 拖拽方向
            foreach (GameObject item in items)
            {
                Rupture(item, glideDir);
            }
        }
        /*
        if (Input.GetMouseButton(0))
        {
            List<GameObject> items = AttackMeteorites(_currentCamera.ScreenToWorldPoint(Input.mousePosition), user.Scope, user.Damage);  // 攻击陨石
            Vector3 glideDir = secondPos - firstPos;  // 拖拽方向
            foreach (GameObject item in items)
            {
                Rupture(item, glideDir);
            }
        }
        */
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = Input.mousePosition;
            foreach (GameObject item in meteoritePointScript.Meteors)
            {
                item.GetComponent<MeteorScript>().canDrag = false;
            }
        }

        // touch
        if (Input.touchCount == 1)
        {
            Vector2 point = Input.GetTouch(0).position;
        }
        else if (Input.touchCount == 2)
        {
            Vector2 point1 = Input.GetTouch(0).position;
            Vector2 point2 = Input.GetTouch(1).position;
        }
    }


    // 玩家滑动手指碰到的陨石相当于攻击陨石一次
    private List<GameObject> AttackMeteorites(Vector2 mousePos, float radius, float damage)
    {
        List<GameObject> items = new List<GameObject>();
        foreach (GameObject item in meteoritePointScript.Meteors)
        {
            MeteorScript meteorScript = item.GetComponent<MeteorScript>();
            if (meteorScript.canDrag && Tools.Intersect(_currentCamera.WorldToScreenPoint(item.transform.position), item.transform.localScale.x,
                _currentCamera.WorldToScreenPoint(mousePos), radius))
            {
                meteorScript.flintiness -= damage;
                if (meteorScript.flintiness <= 0)
                {
                    items.Add(item);
                }
                meteorScript.canDrag = false;
            }
        }
        return items;
    }

    // 裂开
    private void Rupture(GameObject meteor, Vector2 face)
    {
        if (face == Vector2.zero)
        {
            face = new Vector2(0f, 1f);
        }
        if (gameObject != null)
        {
            double n = Math.Sqrt(face.x * face.x + face.y * face.y);
            Vector2 unit = new Vector2(face.x / (float)n, Math.Abs(face.y / (float)n));  // Y轴取绝对值，避免玩家往下拖拽，星球加速撞击
            meteor.GetComponent<MeteorScript>().isDie = true;
            meteor.GetComponent<Rigidbody2D>().AddForce(unit * 300);
            meteoritePointScript.Meteors.Remove(meteor);
        }
    }
}
