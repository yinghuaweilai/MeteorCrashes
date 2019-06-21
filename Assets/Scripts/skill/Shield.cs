using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 护盾
public class Shield : MonoBehaviour
{
    public int level;
    public int cd;
    public int duration;  // 持续时间
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
            if (hit.collider != null && hit.collider.gameObject.tag == "shield")
            {
                click();
            }
        }

        if (Input.GetMouseButtonUp(0) && use == true)
        {
            fire(duration);
        }
    }

    bool use = false;
    // 使用
    private void click()
    {
        use = true;
        Debug.Log("使用护盾： 持续 " + duration);
    }

    public void fire(int duration)
    {
        meteoritePointScript.invincibl = true;
        use = false;
        StartCoroutine(end(duration));
    }

    private IEnumerator end(float duration)
    {
        yield return new WaitForSeconds(duration);
        meteoritePointScript.invincibl = false;
    }


}
