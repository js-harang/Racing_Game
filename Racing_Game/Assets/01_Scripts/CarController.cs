using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("- Preferences")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lateralSpeed;

    [Header("- Moveable Checked")]
    [SerializeField] private bool canMoveLeft = true;
    [SerializeField] private bool canMoveRight = true;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // 왼쪽과 오른쪽 이동 제한 처리
        if (moveHorizontal < 0 && !canMoveLeft)
            moveHorizontal = 0;

        if (moveHorizontal > 0 && !canMoveRight)
            moveHorizontal = 0;

        transform.Translate(Vector3.right * moveHorizontal * lateralSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
            canMoveLeft = false;

        if (collision.gameObject.CompareTag("RightWall"))
            canMoveRight = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
            canMoveLeft = true;

        if (collision.gameObject.CompareTag("RightWall"))
            canMoveRight = true;
    }
}
