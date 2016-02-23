using UnityEngine;
using System.Collections;


public class Planet : MonoBehaviour 
{
	public Vector3 initalSpeed = Vector3.zero;
	public Vector3 vel;
	public int year = 0;

	void FixedUpdate()
	{
		vel = this.GetComponent<Rigidbody> ().velocity;
	}

	void OnCollisionEnter(Collision col)
	{
		if (this.gameObject.transform.localScale.x < col.gameObject.transform.localScale.x)
		{
			col.gameObject.transform.localScale += this.gameObject.transform.localScale;
			col.gameObject.GetComponent<Rigidbody> ().mass += this.gameObject.GetComponent<Rigidbody> ().mass;
			Destroy(this.gameObject);
		} 
		else 
		{
			this.gameObject.transform.localScale += col.gameObject.transform.localScale;
			this.gameObject.GetComponent<Rigidbody> ().mass += col.gameObject.GetComponent<Rigidbody> ().mass;
			Destroy (col.gameObject);
		}
	}

	void OnTriggerEnter(Collider trigger)
	{
		year++;
	}
}

