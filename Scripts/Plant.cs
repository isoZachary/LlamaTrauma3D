using Assets.Scripts.Extensions;
using UnityEngine;

public class Plant : MonoBehaviour
{
	#region Constants
	private const float _healthRegen = .01f;
	private const float _waterLoss = .0025f;
	#endregion

	#region Internals
	private GameObject _stemModel;
	private GameObject _cornModel;
	private GameObject _waterModel;

	private float _health = .5f;
	public float Health
	{
		get => _health;
		set
		{
			_health = MathHelpers.Clamp(value);
		}
	}

	private float _water = .75f;
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
	private PlantManager _plantManager;
	#endregion

	public void Awake()
	{
		_plantManager = GameObject.FindObjectOfType<PlantManager>();
	}

	public void Start()
	{
		_stemModel = transform.GetChild(0).gameObject;
		_cornModel = transform.GetChild(1).gameObject;
		_waterModel = transform.GetChild(2).gameObject;
	}

	public void Update()
	{
		Water -= _waterLoss;
		if (Time.frameCount % 10 == 0 && Water > .5f)
		{
			Health += _healthRegen;
		}
		if (Health == 1)
		{
			_plantManager.CornGrown();
			Health = .5f;
		}
		UpdateModel();
	}

	private void UpdateModel()
	{
		float yScale = 3.5f * Health + .5f;
		_stemModel.transform.localScale = new Vector3(.5f, yScale, .5f);
		_cornModel.SetActive(Health >= .95f);
		_waterModel.SetActive(Water <= .5f);
	}
}
