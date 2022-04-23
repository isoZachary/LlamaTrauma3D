using Assets.Scripts.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Llama : MonoBehaviour
{
	#region Constants
	private const float FleeDistance = 10;
	private const float EatDistance = 1;
	private const float PassiveMovementSpeed = 15;
	private const float FleeingMovementSpeed = 50;
	#endregion

	#region Internals
	private Rigidbody _rigidbody;
	private BoxCollider _boxCollider;
	#endregion

	#region Other GOs
	private Player _player;
	private Plant _targetPlant;
	private LlamaManager _llamaManager;
	#endregion

	private void Awake()
	{
		_player = GameObject.FindObjectOfType<Player>();
		_llamaManager = GameObject.FindObjectOfType<LlamaManager>();
		_rigidbody = GetComponent<Rigidbody>();
		_boxCollider = GetComponent<BoxCollider>();
	}

	public void Start()
	{
		IList<Wall> walls = ObjectExtensions.FindObjectsOfType<Wall>().ToList();
		foreach (Wall wall in walls)
		{
			Physics.IgnoreCollision(_boxCollider, wall.BoxCollider);
		}
		_targetPlant = _llamaManager.GetPlant();
	}

	private void Update()
	{
		// Despawn
		if (transform.position.y < -50)
		{
			Destroy(gameObject);
		}

		// Change target
		if (_targetPlant.Health == 0)
		{
			_targetPlant = _llamaManager.GetPlant();
		}

		// Eat
		if (transform.position.IsWithinDistanceOf(_targetPlant.transform.position, EatDistance, includeY: false))
		{
			_targetPlant.Health -= .025f;
		}

		// Flee player
		if (transform.position.IsWithinDistanceOf(_player.transform.position, FleeDistance, includeY: false))
		{
			Move(transform.position - _player.transform.position, FleeingMovementSpeed);
		}

		// Approach target
		else
		{
			Move(_targetPlant.transform.position - transform.position, PassiveMovementSpeed);
		}
	}

	private void Move(Vector3 direction, float speed)
	{
		direction.y = 0;
		direction.Normalize();
		direction *= speed;
		_rigidbody.AddForce(direction);
		if (direction != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}
