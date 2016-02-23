using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour 
{
	LineRenderer _LR;
	Transform _T;

	public int maxPosCount = 100000;
	public float updateRate = 0.1f;

	List<Vector3> trailPositions;

	void Awake()
	{
		_LR = GetComponent<LineRenderer> ();
		_T = GetComponent<Transform> ();
	}

	void Start()
	{
		trailPositions = new List<Vector3> ();
		StartCoroutine (UpdateTrail ());
	}

	IEnumerator UpdateTrail()
	{
		if (trailPositions.Count > maxPosCount)
			trailPositions.RemoveAt (0);

		trailPositions.Add(_T.position);
		_LR.SetVertexCount (trailPositions.Count);

		for(int i = 0; i < trailPositions.Count; i++)
		{
			_LR.SetPosition(i, trailPositions[i]);
		}

		yield return new WaitForSeconds(updateRate);
		StartCoroutine (UpdateTrail ());


	}
}
