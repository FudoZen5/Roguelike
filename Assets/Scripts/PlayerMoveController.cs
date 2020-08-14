using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	// PUBLIC
	public SimpleTouchController leftController;

	public float speedMovements = 20f;

	// PRIVATE
	private Rigidbody _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		// move
		_rigidbody.AddForce(leftController.GetTouchPosition * speedMovements);
	}

}
