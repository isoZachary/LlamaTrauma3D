using UnityEngine;

public class Camera : MonoBehaviour
{
	#region Constants
	private const float CameraYOffset = 2;
	private const float CameraZOffset = 10;
	private const float MouseRotationSpeed = 4;
	private const float KeyRotationSpeed = 4;
	#endregion

	#region Internals
	private Vector3 _offset;
	#endregion

	#region Other GOs
	private Player _player;
	#endregion

	public void Awake()
	{
		_player = GameObject.FindObjectOfType<Player>();
	}

	public void Start()
	{
		Vector3 position = _player.transform.position;
		_offset = new Vector3(position.x, position.y + CameraYOffset, position.z + CameraZOffset);
	}

	public void Update()
	{
		float rotationInput = 0;
		if (Input.GetKey(KeyCode.Q))
		{
			rotationInput = -KeyRotationSpeed;
		}
		else if (Input.GetKey(KeyCode.E))
		{
			rotationInput = KeyRotationSpeed;
		}
		else
		{
			rotationInput = Input.GetAxisRaw("Mouse X") * MouseRotationSpeed;
		}

		_offset = Quaternion.AngleAxis(rotationInput, Vector3.up) * _offset;
		transform.position = _player.transform.position + _offset;
		transform.LookAt(_player.transform);
	}
}
