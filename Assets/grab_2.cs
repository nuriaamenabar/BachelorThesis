using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab_2 : MonoBehaviour
{
    public GameObject grab2;
    public GameObject grab3;
    public GameObject grab4;
    public prova pr;
    private bool isactive = false;
    // Start is called before the first frame update
    void Start()
    {
        grab2.SetActive(false);
        grab3.SetActive(false);
        grab3.SetActive(false);
        grab4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (pr.cont > 15)
        {
            grab2.SetActive(true);
            
        }
        if (pr.cont > 29)
        {
            grab3.SetActive(true);

        }
        if (pr.cont > 42)
        {
            grab4.SetActive(true);

        }
    }
}
