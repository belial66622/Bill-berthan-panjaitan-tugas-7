using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    float upForce = 1f;
    float sideForce = .1f;
    float mushroomtime = 5f;
    Transform _start;

    private void OnEnable()
    {
        SetPos();
        StartCoroutine(deactivate(mushroomtime));

    }


    private void OnDisable()
    {

    }


    void Start()
    {

        SetPos();
        StartCoroutine(deactivate(mushroomtime) );
    }

    IEnumerator deactivate(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);

    }

    void SetPos()
    {

        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;

    }


}
