using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    Quaternion initialRotation;
    bool dead;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform[] waypoints;
    public int indexWaypoint;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!dead)
        {
            if (Input.GetMouseButton(0) && indexWaypoint!= waypoints.Length)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[indexWaypoint].position, step);
                SelectNextWaypoint();
            }
        }
    }

    void SelectNextWaypoint()
    {
        if (indexWaypoint < waypoints.Length)
        {
            if ((transform.position.x == waypoints[indexWaypoint].position.x) && (transform.position.z == waypoints[indexWaypoint].position.z))
            {
                ++indexWaypoint;

                if (indexWaypoint == waypoints.Length)
                {
                    dead = true;
                    Invoke("RestartGame", 2);
                }
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Respawn()
    {
        transform.rotation = initialRotation;
        transform.position = waypoints[indexWaypoint - 1].position;
        dead = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Obstacle"))
        {
            dead = true;
            Invoke("Respawn", 2);
        }
    }

}
