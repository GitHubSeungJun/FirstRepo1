using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
	[Header ("SCV")]
	public GameObject scvObj;
	[Range(0.0f, 5f)]
	public float scvSpeed = 1f;
	[Range(0.0f, 100f)]
	public float scvRotationSpeed = 50f;
	LayerMask scvLayer;
	LayerMask groundLayer;
	public NavMeshAgent navMeshAgent;
	public Vector3 firstUnitPosition;
	public Vector3 firstMapPosition;
	public bool choiceScv = false;
	private MarineMove marineMoveCheck;
	private void Start()
	{
		scvLayer = LayerMask.GetMask("SCV");
		groundLayer = LayerMask.GetMask("Ground");
	}
	private void Update()
	{ 
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, scvLayer))
			{
				scvObj = hit.transform.gameObject;
				choiceScv = true;
				marineMoveCheck.choiceMarine = false;
			}
		}
		if (choiceScv == true)
		{
			if (Input.GetMouseButton(1))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
				{
					firstMapPosition = hit.point;
					scvObj.transform.LookAt(hit.point);
					scvObj.GetComponent<NavMeshAgent>().SetDestination(hit.point);
				}
			}
		}
	}
}
