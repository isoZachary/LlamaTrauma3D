using Assets.Scripts.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
	#region Constants
	private const float WateringDistance = 10;
	#endregion

	#region Internals
	private Object _plantPrefab;
	#endregion

	#region Other GOs
	private GameManager _gameManager;
	private IList<Plant> _plants;
	#endregion

	public void Awake()
	{
		_gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	public void Start()
	{
		_plantPrefab = Resources.Load(Path.Combine("Prefabs", "Plant"));
		_plants = new List<Plant>();
		for (int x = -10; x <= 10; x += 5)
		{
			for (int z = -10; z <= 10; z += 5)
			{
				Vector3 position = new Vector3(x, 1, z);
				_plants.Add((Instantiate(_plantPrefab, position, Quaternion.identity) as GameObject).GetComponent<Plant>());
			}
		}
	}

	public Plant GetPlantForLlama()
	{
		IList<Plant> highPlants = _plants.Where(p => p.Health > .5f).ToList();
		if (highPlants.Count > 0)
		{
			return highPlants[Random.Range(0, highPlants.Count)];
		}
		return _plants[Random.Range(0, _plants.Count)];
	}

	public void CornGrown()
	{
		_gameManager.Score();
	}

	public void WaterNearPlants(Vector3 position)
	{
		foreach (Plant plant in _plants.Where(p => p.transform.position.IsWithinDistanceOf(position, WateringDistance, includeY: false)))
		{
			plant.Water += .3f;
		}
	}
}
