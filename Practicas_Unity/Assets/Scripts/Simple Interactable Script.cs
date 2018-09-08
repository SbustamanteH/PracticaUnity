using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableArea : MonoBehaviour 
{
	public GameObject infoCanvas;
	public Text panelText;
	public float explosionForce = 50f;
	public float explosionRadius = 30f;
	public Vector3 positionOffset;

	Rigidbody rigidBody;

	void Start()
	{
		infoCanvas.SetActive (false);
		rigidBody = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			infoCanvas.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			infoCanvas.SetActive (false);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			
		}
	}

	public void ChangeText()
	{
		//Debug.Log ("Si jala!");
		panelText.text = "Bien hecho!";
	}

	public void HitChair()
	{
		//Debug.Log ("si jala");
		rigidBody.AddExplosionForce (explosionForce, transform.position + positionOffset, explosionRadius);
	}

	public void ExplodeAll()
	{
		InteractableArea[] chairs = FindObjectsOfType<InteractableArea> ();
		for (int i = 0; i < chairs.Length; i++) 
		{
			chairs [i].HitChair ();
		}
	}
}
