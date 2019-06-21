using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    User user;  // 用于加载和游戏结束后上传
    int health;
    MeteoritePointScript meteoritePointScript;  // 用于获得所有存在的陨石

    void Start()
    {
        user = GameObject.Find("GameScene").GetComponent<GameSceneScript>().user;
        meteoritePointScript = GameObject.Find("MeteoritePoint").GetComponent<MeteoritePointScript>();
        health = user.EarthLevel * 100;
        
    }


    // 陨石碰撞地球后销毁，造成伤害
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Meteor")
        {
            if (!meteoritePointScript.invincibl)
            {
                health -= (int)collision.gameObject.GetComponent<MeteorScript>().flintiness;
            }
            meteoritePointScript.RemoveMeteor(collision.gameObject);
            Debug.Log(health);
        }
    }
}
