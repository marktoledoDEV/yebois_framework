using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Author: Mark Toledo
	Description: An interface that establishes the functions that a state could do in a Animator
*/
namespace YeBoisFramework.StateMachine
{
	public class State : StateMachineBehaviour 
	{
		#region Properties and Fields
		public string stateName { get; set; }
		public StateName stateEnum;
		#endregion

		#region Unity Methods
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
		{
			Debug.Log("Now Entering State: " + stateEnum.ToString());
		}
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Debug.Log("Updating State: " + stateEnum.ToString());
		}
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Debug.Log("Now Exiting State: " + stateEnum.ToString());
		}
		#endregion
	}

	public enum StateName { A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P}
}
