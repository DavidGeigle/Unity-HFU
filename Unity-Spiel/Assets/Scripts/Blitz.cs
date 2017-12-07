﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blitz : MonoBehaviour
{

	BoxCollider box;

	public float t = 2;
	public float Damage;

    public Texture2D BlitzNormal;

    void Start()
	{
		box = gameObject.GetComponent<BoxCollider>();
		box.enabled = false;
	}

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(200, 400, 100, 100), BlitzNormal);
    }


    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && !ZauberCooldown.isOnCooldown)
		{
			ZauberCooldown.isOnCooldown = true;
			ZauberCooldown.timeRemaining = ZauberCooldown.Cooldown;
			box.enabled = true;
			StartCoroutine("BlitzCast");
		}
	}

	IEnumerator BlitzCast()
	{
		yield return new WaitForSeconds(t);
		box.enabled = false;
	}



	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Hit");
		if (other.tag == "Enemy" ) // wenn das getroffene Objekt den Tag Enemy hat
		{
			Debug.Log(other.name +" hat " + Damage + " Schaden erhalten.");
			GameObject.Find(other.name).GetComponent<HealthHandeler>().TakeDamage(Damage);
		}
	}

	
}
