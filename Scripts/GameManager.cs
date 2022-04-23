using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int Corn { get; private set; } = 0;

	public void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void Score()
	{
		Corn++;
	}
}
