using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour, IDamageable
{
	// PUBLIC
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public GameObject Bullet;
	public float speedMovements = 20f;
	// PRIVATE
	[SerializeField] private int currentDamage;
	[SerializeField] private Transform bulletConteiner;
	private float curentQuaternion;
	private Rigidbody _rigidbody;
	private float reload = 1;
	private int keys;

	[SerializeField] private int health;

	public static PlayerController Instance { get; private set; }

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		Instance = this;
	}
	private void Start()
	{
		health = 10;
		UIController.Instance.SetHealth(health);
	}
	void FixedUpdate()
	{
		// move
		_rigidbody.AddForce(leftController.GetTouchPosition * speedMovements);
		reload -= Time.deltaTime;
		if (Vector3.Magnitude(rightController.GetTouchPosition) != 0 && reload < 0)
		{
			curentQuaternion = Vector2.SignedAngle(Vector2.right, rightController.GetTouchPosition);
			Debug.Log(curentQuaternion);
			var bullet = Instantiate(Bullet, transform.position, Quaternion.AngleAxis(curentQuaternion, Vector3.forward),bulletConteiner).GetComponent<MoveBullet>();
			bullet.Init(rightController.GetTouchPosition, new Damage(this, currentDamage));
			reload = 1;
		}
	}
	public void MoveOnNextRoom(GameObject currentPosition, GameObject newPositions)
	{
		currentPosition.SetActive(false);
		newPositions.SetActive(true);
		transform.position = newPositions.transform.position;
	}

	public void GetDamage(Damage damage)
	{
		if (damage.shooter.Equals(this))
			return;
		health -= (int)damage.damage;
		UIController.Instance.SetHealth(health);
		//if (health == 0)
		//GameOver();
	}

	/* private void OnTriggerEnter(Collider other)
	 {
		 if (other.CompareTag("Key"))
		 {
			 keys++;
			 UIController.Instance.SetKeys(keys);
		 }
	 }*/
}

