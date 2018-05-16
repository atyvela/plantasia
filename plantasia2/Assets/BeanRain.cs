using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeanRain : MonoBehaviour
{

    public Vector2 position;
    private float speed;
    private float size;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        size = Random.Range(-0.1f, 0.1f);
        speed = Random.Range(0.8f, 1.1f);
        transform.localScale += new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {

        position.y -= speed * Time.deltaTime;
        transform.position = position;

    }
}
