using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    private void MoveUp()
    {
        transform.position += new Vector3(0, speed, 0);
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, speed, 0);
    }

    private void MoveLeft()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }

    private void MoveRight()
    {
        transform.position += new Vector3(speed, 0, 0);
    }
}
