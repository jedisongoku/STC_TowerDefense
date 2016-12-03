﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingText : MonoBehaviour
{
    public Text floatingText;
	void OnEnable()
    {
        floatingText.text = "+" + GetComponentInParent<Enemy>().enemyCoin + " Coin";
        Vector3 lookPosition = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookPosition);
        //transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
        Invoke("HideText", 2f);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.up, Time.deltaTime);
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }
}
