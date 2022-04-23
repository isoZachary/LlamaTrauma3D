using Assets.Scripts.Extensions;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Constants
	private const float MovementSpeed = 30;
	#endregion

	#region Internals
	private Rigidbody _rigidbody;

	private float _water = 1f;
	public float Water
	{
		get => _water;
		set
		{
			_water = MathHelpers.Clamp(value);
		}
	}
	#endregion

	#region Other GOs
	private Camera _camera;
	private PlantManager _plantManager;
	#endregion

	public void Awake()
	{
		_camera = GameObject.FindObjectOfType<Camera>();
		_plantManager = GameObject.FindObjectOfType<PlantManager>();
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Update()
	{
		UpdateMovement();
		UpateWatering();
	}

	private void UpdateMovement()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
		Vector3 movement = _camera.transform.right * horizontalInput + _camera.transform.forward * verticalInput;
		movement.y = 0;
		movement.Normalize();
		movement *= MovementSpeed;
		_rigidbody.AddForce(movement);
	}

	private void UpateWatering()
	{
		if (Water >= .01f && Input.GetKey(KeyCode.Space))
		{
			Water -= .01f;
			_plantManager.WaterNearPlants(transform.position);
		}
	}
}
