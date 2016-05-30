using UnityEngine;
using System.Collections;

public class CustomReticle : GvrReticle {

	public GameObject fill;

	private float gazeStayTime = 0;
	public float gazeTriggerTime = 1.5f;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		Debug.Log ("****in CustomReticle Start()****");
		fill.transform.localPosition = Vector3.zero;
		fill.transform.localScale = Vector3.zero;
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}


	/// Called when the user is looking on a valid GameObject. This can be a 3D
	/// or UI element.
	///
	/// The camera is the event camera, the target is the object
	/// the user is looking at, and the intersectionPosition is the intersection
	/// point of the ray sent from the camera on the object.
	public override void OnGazeStart(Camera camera, GameObject targetObject, Vector3 intersectionPosition,
		bool isInteractive) {
		base.OnGazeStart (camera, targetObject, intersectionPosition, isInteractive);
		Debug.Log ("****in Custom OnGazeStart()****");
		fill.transform.localPosition = Vector3.zero;
		fill.transform.localScale = Vector3.zero;
	}

	/// Called every frame the user is still looking at a valid GameObject. This
	/// can be a 3D or UI element.
	///
	/// The camera is the event camera, the target is the object the user is
	/// looking at, and the intersectionPosition is the intersection point of the
	/// ray sent from the camera on the object.
	public override void OnGazeStay(Camera camera, GameObject targetObject, Vector3 intersectionPosition,
		bool isInteractive) {
		base.OnGazeStay (camera, targetObject, intersectionPosition, isInteractive);
		if (gazeStayTime <= gazeTriggerTime) {
			gazeStayTime += Time.deltaTime;
		}
		float percentageFill = gazeStayTime / gazeTriggerTime;
		//Debug.Log ("****in Custom OnGazeStay()****, percentageFill: "+percentageFill);
		fill.transform.localPosition = new Vector3 (0, 0, reticleDistanceInMeters);
		float fillDiameter = reticleOuterDiameter * reticleDistanceInMeters * percentageFill * 1.5f;
		fill.transform.localScale = new Vector3 (fillDiameter, fillDiameter, fillDiameter);
	}

	/// Called when the user's look no longer intersects an object previously
	/// intersected with a ray projected from the camera.
	/// This is also called just before **OnGazeDisabled** and may have have any of
	/// the values set as **null**.
	///
	/// The camera is the event camera and the target is the object the user
	/// previously looked at.
	public override void OnGazeExit(Camera camera, GameObject targetObject) {
		base.OnGazeExit (camera, targetObject);
		Debug.Log ("****in Custom OnGazeExit()****");
		gazeStayTime = 0;
		fill.transform.localPosition = Vector3.zero;
		fill.transform.localScale = Vector3.zero;
	}


}

