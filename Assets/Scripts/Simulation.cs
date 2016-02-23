using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour 
{
	public float gravity = 0.01f;
	public string SystemName;
	public List<Planet> planets;
	static Vector3 acceleration;
	static Vector3 direction;
	public float fixedDeltaT;
	private float speed = 10;

	void Start()
	{
		SimulationSetup ();
	}

	void FixedUpdate()
	{
		if(planets.Count > 1)
		{
			foreach(Planet planet in planets)
			{
				RunSimulation(planet);
			}
		}
	}

	void SimulationSetup()
	{
		fixedDeltaT = Time.fixedDeltaTime;
		planets = new List<Planet> ();
		planets.AddRange (FindObjectsOfType (typeof(Planet)) as Planet[]);

		Debug.Log ("There are " + planets.Count + " Orbiting bodies");

		foreach (Planet p in planets) 
		{
			p.GetComponent<Rigidbody>().velocity = p.transform.TransformDirection(p.initalSpeed);
		}

	}

	void RunSimulation(Planet planet)
	{
		acceleration = Vector3.zero;

		foreach(Planet otherP in planets)
		{
			if(planet == otherP) 
				continue;
			direction = otherP.transform.position - planet.transform.position;
			acceleration += gravity * (direction.normalized * otherP.GetComponent<Rigidbody>().mass) / direction.sqrMagnitude;

		}

		planet.GetComponent<Rigidbody>().velocity += acceleration * fixedDeltaT * speed;
		planet.transform.position += planet.GetComponent <Rigidbody>().velocity * fixedDeltaT;
	}
}
