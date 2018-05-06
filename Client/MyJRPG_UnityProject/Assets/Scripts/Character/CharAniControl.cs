using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAniControl : MonoBehaviour {

	public enum State
	{
		Idle,
		Left,
		Right,
		Back,
		Front,
		BattleIdle,
		Attack,
		Hit,

	}

	private Animator animator;
	private State curState;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	
	}

	// Update is called once per frame
	void Update()
	{

		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		if(x < 0)
		{
			PlayAni(State.Left);
		}
		else if(x > 0)
		{
			PlayAni(State.Right);
		}
		else if(y < 0)
		{
			PlayAni(State.Front);
		}
		else if(y > 0)
		{
			PlayAni(State.Back);
		}
		else
		{
			PlayAni(State.Idle);
		}

		//if(x < 0)
		//{
		//	animator.SetInteger("state", (int)State.Left);
		//}
		//else if(x > 0)
		//{
		//	animator.SetInteger("state", (int)State.Right);
		//}
		//else if(y < 0)
		//{
		//	animator.SetInteger("state", (int)State.Front);
		//}
		//else if(y > 0)
		//{
		//	animator.SetInteger("state", (int)State.Back);
		//}
		//else
		//{
		//	animator.SetInteger("state", (int)State.Idle);
		//}
	}

	public void PlayAni(State state)
	{
		if(curState != state)
		{
			curState = state;

			switch(curState)
			{
				case State.Idle:
					animator.Play("Idle");
					break;

				case State.Left:
					animator.Play("Walk_Left");
					break;

				case State.Right:
					animator.Play("Walk_Right");
					break;

				case State.Back:
					animator.Play("Walk_Back");
					break;

				case State.BattleIdle:
					animator.Play("Battle Idle");
					break;

				case State.Attack:
					animator.Play("Attack");
					break;

				case State.Hit:
					animator.Play("Hit");
					break;

			}
		}
	}
}
