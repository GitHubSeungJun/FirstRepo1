using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceUnitonlyMoveScript : MonoBehaviour
{
	bool scv;
	bool marine;
    // Start is called before the first frame update
    void Start()
    {
		scv = GetComponent<UnitMove>().choiceScv;
		marine = GetComponent<MarineMove>().choiceMarine;

	}

    // Update is called once per frame
    void Update()
    {
		if( scv == true)
		{
			marine = false;
		}
		if( marine ==true)
		{
			scv = false;
		}
    }
}
