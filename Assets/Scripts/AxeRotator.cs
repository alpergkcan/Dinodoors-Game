
using UnityEngine;

public class AxeRotator : MonoBehaviour
{
    public float RotateSpeed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x + 1.25f, player.transform.position.y + 0.8f, 0f);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,-RotateSpeed * Time.deltaTime));
        
    }
}
