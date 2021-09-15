using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarineMove : MonoBehaviour
{
	[Header("Marine")]
	public GameObject marineObj;
	[Range(0.0f, 5f)]
	public float marineSpeed = 1f;
	[Range(0.0f, 100f)]
	LayerMask marinLayer;
	LayerMask groundLayer;
	public NavMeshAgent marinenavMeshAgent;
	public bool choiceMarine = false;
	// Start is called before the first frame update
	void Start()
    {
		marinLayer = LayerMask.GetMask("Marine");
		groundLayer = LayerMask.GetMask("Ground");
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, marinLayer))
			{
				marineObj = hit.transform.gameObject;
				Debug.Log(hit.transform.gameObject);
				choiceMarine = true;			
			}
		}
		if (choiceMarine == true)
		{
			if (Input.GetMouseButton(1))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
				{
					marineObj.GetComponent<NavMeshAgent>().enabled = false;
					marineObj.transform.LookAt(hit.point);
					marineObj.GetComponent<NavMeshAgent>().enabled = true;
					Debug.Log(hit.point);
					marineObj.GetComponent<NavMeshAgent>().SetDestination(hit.point);
				}
			}
		}
	}
}
