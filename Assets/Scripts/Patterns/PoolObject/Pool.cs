using System;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Patterns.PoolObject
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private bool _logStatus = false;
	    
	    [Space,SerializeField] private List<PoolItem> _poolItems = new ();

	    private bool _dirty = false;

	    private Transform _root;

	    private readonly Dictionary<GameObject, ObjectPool<GameObject>> _prefabLookup = new ();
	    private readonly Dictionary<GameObject, ObjectPool<GameObject>> _instanceLookup = new ();

	    private void Awake()
	    {
		    _root = new GameObject().transform;
		    
		    _root.SetParent(transform);
		    
		    _root.name = "Pool";
	    }

	    private void Start()
	    {
		    FirstWarmPool();
	    }

	    private void Update()
	    {
		    if (_logStatus && _dirty)
		    {
			    PrintStatus();
			    
			    _dirty = false;
		    }
	    }

	    private void OnDisable()
	    {
		    _prefabLookup.Clear();
		    _instanceLookup.Clear();
	    }

	    private void Warm(GameObject prefab, int size)
	    {
		    prefab.gameObject.SetActive(false);

		    if (_prefabLookup.ContainsKey(prefab))
		    {
			    throw new Exception($"Pool for prefab {prefab.name} has already been created");
		    }

		    ObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => InstantiatePrefab(prefab), size);
		    
		    _prefabLookup[prefab] = pool;
		    
		    _dirty = true;
	    }

	    private GameObject Spawn(GameObject prefab)
	    {
		    return Spawn(prefab, Vector3.zero, Quaternion.identity);
	    }

	    private GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
	    {
		    if (!_prefabLookup.ContainsKey(prefab))
		    {
			    WarmPool(prefab, 1);
		    }

		    ObjectPool<GameObject> pool = _prefabLookup[prefab];

		    GameObject clone = pool.GetItem();
		    
		    clone.transform.position = position;
		    clone.transform.rotation = rotation;
		    clone.SetActive(true);

		    _instanceLookup.Add(clone, pool);
		    
		    _dirty = true;
		    
		    return clone;
	    }

	    private void Release(GameObject clone)
	    {
		    clone.SetActive(false);

		    if (_instanceLookup.ContainsKey(clone))
		    {
			    _instanceLookup[clone].ReleaseItem(clone);
			    _instanceLookup.Remove(clone);
			    _dirty = true;
		    }
		    else
		    {
			    Debug.LogWarning($"No pool contains the object: {clone.name}");
		    }
	    }

	    private GameObject InstantiatePrefab(GameObject prefab)
	    {
		    GameObject go = Instantiate(prefab);
		    
		    if (_root != null)
		    {
			    go.transform.parent = _root;
		    }

		    return go;
	    }

	    private void PrintStatus()
	    {
		    foreach (var obj in _prefabLookup)
		    {
			    Debug.Log($"Object Pool for Prefab: {obj.Key.name} In Use: {obj.Value.CountUsedItems} Total: {obj.Value.Count}");
		    }
	    }

	    private void FirstWarmPool()
	    {
		    foreach (PoolItem pool in _poolItems)
		    {
			    WarmPool(pool.Prefab, pool.Count);
		    }
	    }

	    private void WarmPool(GameObject prefab, int size)
	    {
		    Warm(prefab, size);
	    }

	    public GameObject SpawnObject(GameObject prefab)
	    {
		    return Spawn(prefab);
	    }

	    public GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
	    {
		    return Spawn(prefab, position, rotation);
	    }

	    public void ReleaseObject(GameObject clone)
	    {
		    Release(clone);
	    }
    }
}