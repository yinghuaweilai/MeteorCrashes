using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneScript : MonoBehaviour
{
    public Button btn_pause;
    public User user;  // 加载游戏难度、道具等级等
    public MeteoritePointScript meteoritePointScript;  // 陨石生成的管理类

    void Awake()
    {
        user = UserProtobuf.Instance.UserDeserialization();  // 反序列化，读取User
        meteoritePointScript = GameObject.Find("MeteoritePoint").GetComponent<MeteoritePointScript>();
    }

    private void Start()
    {
        //设置监听
        btn_pause.onClick.AddListener(PauseGame);
    }

    //暂停按钮事件
    private void PauseGame()
    {
        if (!GameObject.Find("PauseScene"))
        {
            GameObject pauseScene = Instantiate(Resources.Load<GameObject>("Prefabs/PauseScene"));
            pauseScene.transform.SetParent(transform, false);
            pauseScene.name = "PauseScene";
            pauseScene.transform.position += new Vector3(0, 0, -10);

            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        //取消监听
        btn_pause.onClick.RemoveListener(PauseGame);
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
            foreach (GameObject item in meteoritePointScript.Meteors)
            {
                item.GetComponent<MeteorScript>().canDrag = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            AttackMeteorites(Input.mousePosition, user.Scope, user.Damage);  // 攻击陨石
            Vector3 glideDir = firstPos - secondPos;  // 拖拽方向
            Debug.Log(glideDir);
        }
        if (Input.GetMouseButtonUp(0))
        {
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
    private void AttackMeteorites(Vector2 mousePos, float radius, float damage)
    {
        List<GameObject> items = new List<GameObject>();
        foreach (GameObject item in meteoritePointScript.Meteors)
        {
            MeteorScript meteorScript = item.GetComponent<MeteorScript>();
            if (meteorScript.canDrag && Tools.Intersect(item.transform.position, item.transform.localScale.x,
                mousePos, radius))
            {
                meteorScript.flintiness -= damage;
                if (meteorScript.flintiness <= 0)
                {
                    Debug.Log("裂开");
                    items.Add(item);
                }
                meteorScript.canDrag = false;
            }
        }
        foreach (GameObject item in items)
        {
            Rupture(item);
        }
    }

    // 裂开
    private void Rupture(GameObject meteor)
    {
        meteor.GetComponent<MeteorScript>().isDie = true;
        meteor.GetComponent<Rigidbody2D>().AddForce(new Vector2(5000,50000));
        meteoritePointScript.Meteors.Remove(meteor);
    }
}
