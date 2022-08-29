using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField]private GameObject objPrefab;
    [SerializeField] List<GameObject> _pooledObject;
    [SerializeField] private int amount;
    Transform _startPos;

    private void Start()
    {
        _pooledObject = new List<GameObject>();
        GameObject temp;
        _startPos = transform;
        for (int i = 0; i < amount; i++)
        {

            temp = Instantiate(objPrefab,transform);
            temp.SetActive(false);
            _pooledObject.Add(temp);
        }
    }


    void FixedUpdate(){
        GameObject Mushroom = GetPooled();
        if (Mushroom != null)
        {
            Mushroom.transform.SetPositionAndRotation(_startPos.position,_startPos.rotation);
            Mushroom.SetActive(true);
        }
        else if(Mushroom == null)
            addpooledobject();
        
        //Instantiate(objPrefab, transform.position, Quaternion.identity);
    }


    GameObject GetPooled()
    {
        for (int i = 0; i < _pooledObject.Count; i++)
        {
            if (!_pooledObject[i].activeInHierarchy)
            { return _pooledObject[i]; }
        }
        return null;
    }


    void addpooledobject()
    {
        GameObject temp;
        temp = Instantiate(objPrefab,transform);
        temp.SetActive(true);
        _pooledObject.Add(temp);
    }
}
