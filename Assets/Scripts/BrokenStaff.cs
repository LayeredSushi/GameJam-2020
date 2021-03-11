using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenStaff : MonoBehaviour
{
	[SerializeField]
	Transform firepoint;

	public GameObject[] spells;
	static int activeSpellIndex;

	[SerializeField]
	AudioManager audioManager;



	private void Update()
	{
		for (int i = 1; i <= spells.Length; i++)
		{
			if (Input.GetKeyDown("" + i))
			{
				activeSpellIndex = i - 1;
				audioManager.PlayNofireball();
			}
			//Debug.Log("selected" + activeSpellIndex);
		};

		
		
	}

	public void Shoot()
	{
		/*Vector3 vec = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 targetPosition = Vector3.zero;
		if (Physics.Raycast(ray, out RaycastHit hit, 1000))
		{
			targetPosition = hit.point;
			targetPosition.y = 3.37f;
			Debug.Log("jast target "+ targetPosition);

			Debug.Log("transform minus  " + (transform.position-targetPosition));
		}

		//Debug.Log(vec);
		float angle = Mathf.Atan2(vec.y, vec.x)*Mathf.Rad2Deg;
		*/
		GameObject spell = Instantiate(spells[activeSpellIndex], firepoint.position, firepoint.rotation);
		if (activeSpellIndex == 0)
		{
			audioManager.PlaySpell();
		}
		if(activeSpellIndex == 1)
		{

			audioManager.PlayFireBall();
		}
		//spell.transform.eulerAngles = new Vector3(0, gameObject.transform.rotation.y*180, 90);
	}

	public int GetActiveSpellndex()
	{
		return activeSpellIndex;
	}

}
