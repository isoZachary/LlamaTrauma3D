using UnityEngine;

public class Wall : MonoBehaviour
{
    public BoxCollider BoxCollider { get; private set; }

    public void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }
}
