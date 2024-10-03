using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField] public List<Pool> pools;  
    [SerializeField] public Dictionary<string, Queue<GameObject>> poolDictionnary;


    #region singleton
    public static PoolingManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionnary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't excist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionnary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.parent = parent;

        return objectToSpawn;
    }

    public GameObject SendBackFromPool(string tag, GameObject objectToSendBack)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't excist.");
            return null;
        }
        poolDictionnary[tag].Enqueue(objectToSendBack);
        objectToSendBack.SetActive(false);

        return objectToSendBack;
    }
}
