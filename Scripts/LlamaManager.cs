using System.IO;
using UnityEngine;

public class LlamaManager : MonoBehaviour
{
	#region Internals
	private Object _llamaPrefab;
	#endregion

	#region Other GOs
	private PlantManager _plantManager;
	#endregion

	public void Awake()
	{
		_plantManager = GameObject.FindObjectOfType<PlantManager>();
	}

	public void Start()
	{
		_llamaPrefab = Resources.Load(Path.Combine("Prefabs", "Llama"));
	}

	public void Update()
	{
		if (Time.frameCount >= 300 && Time.frameCount <= 1200 && Time.frameCount % 200 == 0)
		{
			CreateLlama();
		}
		else if (Time.frameCount > 1200 && Time.frameCount % 125 == 0)
		{
			CreateLlama();
		}
	}

	private void CreateLlama()
	{
		float x, z;
		switch ((int)Random.Range(0, 3))
		{
			case 0:
				x = -15;
				z = Random.Range(-15, 15);
				break;
			case 1:
				x = Random.Range(-15, 15);
				z = 15;
				break;
			default:
				x = 15;
				z = Random.Range(-15, 15);
				break;
		}

		Vector3 startPosition = new Vector3(x, 1, z);
		Instantiate(_llamaPrefab, startPosition, Quaternion.identity);
	}

	public Plant GetPlant()
	{
		return _plantManager.GetPlantForLlama();
	}
}
