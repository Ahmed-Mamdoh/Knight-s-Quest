using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform player;
    [SerializeField] private float lookAhead;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);

    }
}
