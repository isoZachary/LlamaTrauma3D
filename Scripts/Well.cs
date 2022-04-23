using Assets.Scripts.Extensions;
using UnityEngine;

public class Well : MonoBehaviour
{
	private const float _waterRegen = .01f;
	private const float _regenDistance = 5;

	private Player _player;

	public void Awake()
	{
		_player = GameObject.FindObjectOfType<Player>();
	}

	public void Update()
	{
		if (transform.position.IsWithinDistanceOf(_player.transform.position, _regenDistance, includeY: false))
		{
			_player.Water += _waterRegen;
		}
	}
}
