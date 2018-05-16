using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class popUpscript : MonoBehaviour
{

    public GameObject popup; // prefab to instantiate
    public Canvas canvas; // father canvas
    private Vector2 position;// = new Vector2(0, 0);
  
    

    public void PopUP()

    {
        ;
        position = new Vector2(Random.Range(-200f, 200f), Random.Range(30f, 100f));
        GameObject inst = (GameObject)Instantiate(popup, position, Quaternion.identity);
        inst.transform.SetParent(canvas.transform, false);
        Destroy(inst, 0.7f);
    }


}