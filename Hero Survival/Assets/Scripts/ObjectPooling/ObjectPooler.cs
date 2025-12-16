using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public GameObject prefab;
        public string objectTag;
        public int size;
    }

    public List<ObjectPool> pools;
    public Dictionary<string, Queue<GameObject>> poolsOfDictionary;

    void Start()
    {
        poolsOfDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPool pool in pools)
        {
            Queue<GameObject> obj = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject objPool = Instantiate(pool.prefab);
                objPool.SetActive(false);
                obj.Enqueue(objPool);
            }

            poolsOfDictionary.Add(pool.objectTag, obj);
        }
    }

    public GameObject SpawnObjects(string tag, Vector2 position, Quaternion rotation)
    {
        GameObject objToSpawn = poolsOfDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolsOfDictionary[tag].Enqueue(objToSpawn);
        
        return objToSpawn;
    }
}
