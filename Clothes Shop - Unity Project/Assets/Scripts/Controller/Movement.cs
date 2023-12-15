using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(0, speed) * Time.fixedDeltaTime);
        //transform.position += new Vector3(0, speed, 0);
    }

    private void MoveDown()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position - new Vector2(0, speed) * Time.fixedDeltaTime);
        //transform.position -= new Vector3(0, speed, 0);
    }

    private void MoveLeft()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position - new Vector2(speed, 0) * Time.fixedDeltaTime);
        //transform.position -= new Vector3(speed, 0, 0);
    }

    private void MoveRight()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(speed, 0) * Time.fixedDeltaTime);
        //transform.position += new Vector3(speed, 0, 0);
    }
}
