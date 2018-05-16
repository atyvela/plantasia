using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BeanRainScript : MonoBehaviour
{

    public GameObject popup; // prefab to instantiate
    public Canvas canvas; // father canvas
    private Vector3 position;// = new Vector2(0, 0);

    private void Start()
    {
        InvokeRepeating("Rain", 1.0f, 0.1f);
    }

    public void Rain()

    {
        ;
        position = new Vector3(Random.Range(-450f, 450f), Random.Range(30f, 100f), Random.Range(-50f, 0f));
        GameObject inst = (GameObject)Instantiate(popup, position, Quaternion.identity);
        inst.transform.SetParent(canvas.transform, false);
        Destroy(inst, 15f);
    }


}