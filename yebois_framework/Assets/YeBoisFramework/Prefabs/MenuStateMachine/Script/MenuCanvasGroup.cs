/*
	Author: Mark Toledo
	Description: MenuCanvasGroup handles the specific of each individual menu
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace YeBoisFramework.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class MenuCanvasGroup : MonoBehaviour 
	{
		#region Properties and Fields
		#endregion

		#region Unity Methods
		private void OnEnable()
		{
			OnStateEnter();
		}
		private void Update()
		{
			OnStateUpdate();
		}
		private void OnDisable()
		{
			OnStateExit();
		}
		#endregion

		#region Custom Methods
		protected virtual void OnStateEnter() { }
		protected virtual void OnStateUpdate() { }
		protected virtual void OnStateExit() { }
		#endregion
	}
}
