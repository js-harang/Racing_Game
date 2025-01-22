using UnityEngine;

public class Gas : MonoBehaviour
{
    [SerializeField] private float fallSpeed;

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < -5f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.gas = Mathf.Min(gameManager.gas + 30, 100);
            Destroy(gameObject);
        }
    }
}
