using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(new Vector2 (0,1) * Time.deltaTime);
    }

    public void StartMotion(int damageDealt)
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x,pos.y,0);
        GetComponent<Text>().text = "-" + damageDealt;
        GetComponent<Animation>().Play("ClickTextFade");
    }
}
