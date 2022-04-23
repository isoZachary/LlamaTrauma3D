using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
	//private Canvas _canvas;
	private GameManager _gameManager;
	private Player _player;
	private Image _waterImage;
	private Text _cornText;

	public void Awake()
	{
		//_canvas = GameObject.FindObjectOfType<Canvas>();
		_gameManager = GameObject.FindObjectOfType<GameManager>();
		_player = GameObject.FindObjectOfType<Player>();
		_waterImage = GameObject.FindObjectOfType<Water>().GetComponent<Image>();
		_cornText = GameObject.FindObjectOfType<Corn>().GetComponent<Text>();
	}

	public void Start()
	{
		//Text x = DefaultControls.CreateText(new DefaultControls.Resources()).GetComponent<Text>();
		//x.transform.position = new Vector3(-0, 0, 0);
		//x.text = new string('W', 10);
		////x.transform.SetParent(_canvas.transform);
		//var y = _canvas.transform.GetChild(0);
		//x.transform.SetParent(y);

		//Text x = _canvas.gameObject.AddComponent<Text>();
		//x.transform.SetParent(x.transform);
		//x.transform.position = new Vector3(0, 0, 0);
		//x.text = "hello world";
	}

	public void Update()
	{
		_waterImage.transform.localScale = new Vector3(_player.Water, 1, 1);
		_cornText.text = _gameManager.Corn.ToString();
	}
}
