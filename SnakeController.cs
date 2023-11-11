using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public int Gap = 20;

    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // store position history
        PositionHistory.Insert(0, transform.position);

        // move body parts
        int index = 0;
        //foreach (var body in BodyParts)
        //{
        //    Vector3 point = PositionHistory[Mathf.Min(index * Gap, PositionHistory.Count - 1)];
        //    body.transform.position = point;
        //    index++;
        //}

    }

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sphere"))
        {
            Destroy(other.gameObject);
            GrowSnake();
        }
    }
}
