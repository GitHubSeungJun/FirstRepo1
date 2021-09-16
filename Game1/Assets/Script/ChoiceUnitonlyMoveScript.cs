using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChoiceUnitonlyMoveScript : MonoBehaviour
{
	public GameObject target;
	public GameObject mouseClick;
	public GameObject mouseClickClone;
	LayerMask MapLayer;
	[Range(0.0f, 10f)]
	public float moveSpeed = 5f;
	// Start is called before the first frame update
	void Start()
    {
		MapLayer = LayerMask.GetMask("Ground");
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(0))
		{
			target = GetClickedObject();
		}
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, MapLayer))
			{
				mouseClickClone = Instantiate(mouseClick, hit.point, Quaternion.identity) as GameObject;
				StartCoroutine(ClickMove());
				Destroy(mouseClickClone);
				target.GetComponent<NavMeshAgent>().enabled = false;
				target.transform.LookAt(hit.point);
				target.GetComponent<NavMeshAgent>().enabled = true;
				target.transform.LookAt(hit.point);
				target.GetComponent<NavMeshAgent>().SetDestination(hit.point);
			}
		}
	}
	private GameObject GetClickedObject()
	{
		RaycastHit hit;
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(true == Physics.Raycast(ray.origin,ray.direction *10, out hit))
		{
			target = hit.collider.gameObject;
		}

		return target;
	}
	IEnumerator ClickMove()
	{
		yield return new WaitForSeconds(1f);
	}
}

