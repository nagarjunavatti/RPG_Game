using UnityEngine;

public class practice : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Material mat = transform.GetComponent<MeshRenderer>().material;
            mat.color = Color.blue;
        }
    }
}