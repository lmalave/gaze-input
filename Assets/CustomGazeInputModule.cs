using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CustomGazeInputModule : GazeInputModule {

	private float selectedTime = 0;
	public float triggerTime = 1.5f;

	public override void Process() {
		base.Process ();
		HandleTimedTrigger ();
	}
		
	private void HandleTimedTrigger() {
		if (pointerData.pointerCurrentRaycast.gameObject) {				
			selectedTime += Time.deltaTime;
			if (selectedTime > triggerTime) {
				Debug.Log ("***in UpdateTimedTrigger, going from Selected to Triggered State***, current object: " + pointerData.pointerCurrentRaycast.gameObject.name);
				HandleTrigger ();
				HandlePendingClick ();
				selectedTime = 0;
			} else {
				//Debug.Log ("***in UpdateTimedTrigger, selecctedTime***, current object: " + selectedTime);
			}
		} else {
			selectedTime = 0;
		}

	}



}
