using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject Walkable;
    public GameObject NonWalkable;
    public Transform checkNextCollision;
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, -90, 0),
    currentDirection = Vector3.zero;
    public float waitTime = 0.5f;
    public List<string> comandos = new List<string>();
    bool startMove = false;
    // Start is called before the first frame update
    void Start()
    {
        currentDirection = up;
    }
    public void RellenarComando(string comando)
    {
        comandos.Add(comando);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Recarga");
        if(other.tag == "NonWalkable")
        {
            SceneManager.LoadScene(0);
        }
    }
    public void StartMove()
    {
        if(startMove==false)
        {
            startMove = true;
            StartCoroutine(Move(comandos));
        }
    }
    IEnumerator Move(List<string> com)
    {
        WaitForSeconds wait = new WaitForSeconds(waitTime);
        foreach (var item in com)
        {
            
            if (item=="Forward")
            {
                Debug.Log("palante");
                if(Physics.OverlapSphere(checkNextCollision.position,0).Length==0)
                    transform.Translate(0, 0, 1,Space.Self);
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
            else if (item == "GirarIz")
            {
                Debug.Log("iz");
                currentDirection = currentDirection + left;
            }
            else if (item == "GirarDer")
            {
                Debug.Log("der");
                currentDirection = currentDirection + right;
            }
            
            transform.localEulerAngles = currentDirection;
            yield return wait;
        }
        SceneManager.LoadScene(0);
    }
}
