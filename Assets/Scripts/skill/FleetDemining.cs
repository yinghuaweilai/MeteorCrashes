using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleetDemining : MonoBehaviour
{
    public int level;
    public int cd;
    public int damage;
    public MeteoritePointScript meteoritePointScript;
    public Image img;
    private Camera _currentCamera;

    private void Start()
    {
        meteoritePointScript = GameObject.Find("MeteoritePoint").GetComponent<MeteoritePointScript>();
        _currentCamera = Camera.main;
    }


    RaycastHit2D hit;
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag == "fleet")
            {
                click();
            }
        }

        if (Input.GetMouseButtonUp(0) && use == true)
        {
            fire(_currentCamera.ScreenToWorldPoint(Input.mousePosition), damage, meteoritePointScript.Meteors);
        }
    }

    bool use = false;
    // 使用
    private void click()
    {
        use = true;
        Debug.Log("使用舰队扫雷： 伤害 " + damage);
    }

    List<GameObject> items = new List<GameObject>();
    public void fire(Vector2 mousePos, int damage, List<GameObject> meteors)
    {
        items.Clear();
        foreach (var item in meteors)
        {
            if (item != null)
            {
                MeteorScript meteorScript = item.GetComponent<MeteorScript>();
                if (normalDirectionIntersect(_currentCamera.WorldToScreenPoint(item.transform.position), item.transform.localScale.x,
                    _currentCamera.WorldToScreenPoint(mousePos), 0))
                {
                    meteorScript.flintiness -= damage;
                    if (meteorScript.flintiness <= 0)
                    {
                        item.GetComponent<MeteorScript>().isDie = true;
                        items.Add(item);
                    }
                    meteorScript.canDrag = false;
                }
            }
        }
        foreach (var item in items)
        {
            meteoritePointScript.Meteors.Remove(item);
            Destroy(item);
        }
        use = false;
    }

    public static bool normalDirectionIntersect(Vector2 objPos, float objscale, Vector2 mousePos, float width)
    {

        double distanceMax = Mathf.Abs(objPos.x - mousePos.x);
        if (distanceMax <= objscale * 40 + width * 10)
            return true;
        else
            return false;
    }
}
