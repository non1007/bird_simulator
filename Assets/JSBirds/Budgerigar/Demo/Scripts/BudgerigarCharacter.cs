using UnityEngine;
using System.Collections;

public class BudgerigarCharacter : MonoBehaviour
{
	public Animator budgerigarAnimator;
	public float animSpeed = 5f;
	Rigidbody budgerigarRigid;
	public bool isFlying = false; //飛んでいるかどうか
	public float forwardSpeed = 0f;
	public float turnAcceleration = 0f;
	public float upDownAcceleration = 0f;
	public float forwardAccelerationMultiplier = 1f;
	public float turnAccelerationMultiplier = 1f;
	public float upDownAccelerationMultiplier = 1f;
	public float forwardAcceleration = 0f;
	public bool isGrounded;
	public float groundCheckDistance = 0.1f;
	public float groundCheckOffset = 0.01f;
	public bool soaring = false; //急上昇しているかどうか
	float soaringTime = 0f;

	void Start()
	{
		budgerigarAnimator = GetComponent<Animator>();
		budgerigarAnimator.speed = animSpeed;
		budgerigarRigid = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Move();
		CheckGroundStatus();

		if (soaring)
		{
			soaringTime += Time.deltaTime;
			if (soaringTime > 1f)
			{
				soaring = false;
			}
		}
	}

	public void AnimSpeedSet(float speed)
	{
		animSpeed = speed;
		budgerigarAnimator.speed = animSpeed;
	}

	//着地
	public void Landing()
	{
		budgerigarAnimator.SetTrigger("Landing");
		budgerigarRigid.useGravity = true;
		budgerigarAnimator.applyRootMotion = true;
		isFlying = false;
	}

	//急上昇
	public void Soar()
	{
		budgerigarAnimator.SetTrigger("Soar");
		budgerigarRigid.useGravity = false;
		budgerigarAnimator.applyRootMotion = false;
		isFlying = true;
		isGrounded = false;
		soaring = true;
		soaringTime = 0f;
		upDownAcceleration = 1f;
	}

	public void HopForward()
	{
		budgerigarAnimator.SetTrigger("HopForward");
	}

	public void HopBack()
	{
		budgerigarAnimator.SetTrigger("HopBack");
	}

	public void HopRight()
	{
		budgerigarAnimator.SetTrigger("HopRight");
	}

	public void HopLeft()
	{
		budgerigarAnimator.SetTrigger("HopLeft");

	}

	public void Attack()
	{
		budgerigarAnimator.SetTrigger("Attack");
	}

	public void Hit()
	{
		budgerigarAnimator.SetTrigger("Hit");
	}

	public void Bathing()
	{
		budgerigarAnimator.SetTrigger("Bathing");
	}

	public void Chirp()
	{
		budgerigarAnimator.SetTrigger("Chirp");
	}

	public void Grooming()
	{
		budgerigarAnimator.SetTrigger("Grooming");
	}

	public void EatStart()
	{
		budgerigarAnimator.SetBool("IsEating", true);
	}

	public void EatEnd()
	{
		budgerigarAnimator.SetBool("IsEating", false);
	}

	public void Death()
	{
		budgerigarAnimator.SetBool("IsLived", false);
	}

	public void Rebirth()
	{
		budgerigarAnimator.SetBool("IsLived", true);
	}

	void CheckGroundStatus()
	{
		RaycastHit hitInfo;

		//接地判定
		isGrounded = Physics.Raycast(transform.position + (Vector3.up * groundCheckOffset), Vector3.down, out hitInfo, groundCheckDistance);

		if (isGrounded)
		{
			budgerigarAnimator.SetBool("IsGrounded", true);

			if (isFlying & !soaring)
			{
				Landing();
			}
			if (!isFlying)
			{
				budgerigarAnimator.applyRootMotion = true;
			}

		}
		else
		{
			budgerigarAnimator.applyRootMotion = false;
			budgerigarAnimator.SetBool("IsGrounded", false);
		}

	}
	public void Move()
	{
		//加速度→０、時間が経つにつれて加速度が０に近づく
		upDownAcceleration = Mathf.Lerp(upDownAcceleration, 0f, Time.deltaTime);
		
		//飛行中
		if (isFlying)
		{
			//加速度の設定
			budgerigarAnimator.SetFloat("ForwardAcceleration", forwardAcceleration); //前
			budgerigarAnimator.SetFloat("UpDownAcceleration", upDownAcceleration); //上下

			budgerigarRigid.AddForce(transform.forward * (forwardAcceleration + .3f) * forwardAccelerationMultiplier + transform.up * (upDownAcceleration + (Mathf.Abs(forwardAcceleration) - .9f) * .4f) * upDownAccelerationMultiplier);
			budgerigarRigid.AddTorque(transform.up * turnAcceleration * turnAccelerationMultiplier);
		}

		//前方向のスピードや加速度の設定
		budgerigarAnimator.SetFloat("Forward", forwardSpeed);
		budgerigarAnimator.SetFloat("Turn", turnAcceleration);
	}
}
