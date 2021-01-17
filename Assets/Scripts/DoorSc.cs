using UnityEngine;

public class DoorSc : MonoBehaviour
{
    
   


    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * PlayerInput.MSForDoors;
        transform.position = new Vector3(16, Random.Range(-3.9f, 0.5f), 0f);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Axe"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }

}
