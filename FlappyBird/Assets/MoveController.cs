using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float Speed;
    public float SpawnPoint;
    public float DespawnPoint;
    public float MinY;
    public float MaxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(MinY, MaxY), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BirdController.HasStarted || BirdController.Gameover) return;

        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime,
            transform.position.y, transform.position.z);

        if(transform.position.x <= DespawnPoint)
        {
            transform.position = new Vector3(SpawnPoint, Random.Range(MinY, MaxY), transform.position.z);
        }
    }
}
