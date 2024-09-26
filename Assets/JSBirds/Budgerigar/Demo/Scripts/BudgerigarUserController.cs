using UnityEngine;
using System.Collections;

public class BudgerigarUserController : MonoBehaviour
{

	public BudgerigarCharacter budgerigarCharacter;

	void Start()
	{
		budgerigarCharacter = GetComponent<BudgerigarCharacter>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			budgerigarCharacter.HopLeft();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			budgerigarCharacter.HopForward();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			budgerigarCharacter.HopRight();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			budgerigarCharacter.HopBack();
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			budgerigarCharacter.Hit();
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			budgerigarCharacter.Bathing();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			budgerigarCharacter.Chirp();
		}

		if (Input.GetKeyDown(KeyCode.G))
		{
			budgerigarCharacter.Grooming();
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			budgerigarCharacter.Death();
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			budgerigarCharacter.Rebirth();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			budgerigarCharacter.EatStart();
		}

		if (Input.GetKeyUp(KeyCode.E))
		{
			budgerigarCharacter.EatEnd();
		}

		if (Input.GetButtonDown("Jump"))
		{
			if (!budgerigarCharacter.isFlying)
			{
				budgerigarCharacter.Soar();
			}
		}

		if (Input.GetButtonDown("Fire1"))
		{
			budgerigarCharacter.Attack();
		}

		if (Input.GetKey(KeyCode.U))
		{
			budgerigarCharacter.upDownAcceleration = Mathf.Lerp(budgerigarCharacter.upDownAcceleration, 1f, Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.N))
		{
			budgerigarCharacter.upDownAcceleration = Mathf.Lerp(budgerigarCharacter.upDownAcceleration, -1f, Time.deltaTime);
		}
	}


	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");
		budgerigarCharacter.forwardAcceleration = v;
		budgerigarCharacter.turnAcceleration = h;
		budgerigarCharacter.forwardSpeed = v;
	}
}
