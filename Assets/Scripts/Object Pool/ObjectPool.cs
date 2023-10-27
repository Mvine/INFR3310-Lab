using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class ObjectPool : Singleton<ObjectPool>
	{
		[SerializeField]
		int defaultInitialQuantity = 1;

		Dictionary<int, Queue<PoolableObject>> m_poolDictionary = new Dictionary<int, Queue<PoolableObject>>();

		public void CreatePool(PoolableObject a_prefab, int a_initialQuantity)
		{
			GameObject prefabObject = a_prefab.gameObject;

			int poolKey = a_prefab.GetInstanceID();
			if (m_poolDictionary.ContainsKey(poolKey))
			{
				return;
			}

			m_poolDictionary.Add(poolKey, new Queue<PoolableObject>());

			GameObject newPoolObject = new GameObject(GetPoolName(prefabObject));
			newPoolObject.transform.parent = transform;

			for (int i = 0; i < a_initialQuantity; i++)
			{
				GameObject newObject = SpawnNewObject(prefabObject, newPoolObject.transform, poolKey, false);

				m_poolDictionary[poolKey].Enqueue(newObject.GetComponent<PoolableObject>());
			}
		}

		string GetPoolName(GameObject a_objectPrefab)
		{
			return a_objectPrefab.name + " Pool";
		}

		GameObject SpawnNewObject(GameObject a_objectPrefab, Transform a_parent, int a_poolId, bool a_activate)
		{
			GameObject newObject = Instantiate(a_objectPrefab, a_parent);

			newObject.GetComponent<PoolableObject>().PoolId = a_poolId;

			newObject.SetActive(a_activate);

			return newObject;
		}

		public GameObject GetObject(PoolableObject a_prefab, bool a_triggerReuse = true)
		{
			GameObject prefabObject = a_prefab.gameObject;

			int poolKey = a_prefab.GetInstanceID();
			if (!m_poolDictionary.ContainsKey(poolKey))
			{
				CreatePool(a_prefab, defaultInitialQuantity);
			}
			var pool = m_poolDictionary[poolKey];

			GameObject objectInstance;

			if (pool.Count <= 0)
			{
				Transform poolTransform = transform.Find(GetPoolName(prefabObject));

				objectInstance = SpawnNewObject(prefabObject, poolTransform, poolKey, true);
			}
			else
			{
				objectInstance = pool.Dequeue().gameObject;

				objectInstance.SetActive(true);

				if (a_triggerReuse)
				{
					objectInstance.GetComponent<PoolableObject>().OnReuse();
				}
			}

			return objectInstance;
		}

		public GameObject GetObject(PoolableObject a_prefab, Vector3 a_position, Quaternion a_rotation, bool a_triggerReuse = true)
		{
			GameObject objectToGet = GetObject(a_prefab, false);
			objectToGet.transform.position = a_position;
			objectToGet.transform.rotation = a_rotation;

			if (a_triggerReuse)
			{
				objectToGet.GetComponent<PoolableObject>().OnReuse();
			}

			return objectToGet;
		}

		public GameObject GetObject(PoolableObject a_prefab, Vector3 a_position, bool a_triggerReuse = true)
		{
			GameObject objectToGet = GetObject(a_prefab, false);
			objectToGet.transform.position = a_position;

			if (a_triggerReuse)
			{
				objectToGet.GetComponent<PoolableObject>().OnReuse();
			}

			return objectToGet;
		}

		public void ReturnObject(PoolableObject a_poolable)
		{
			if (!a_poolable)
			{
				Debug.LogWarning("Tried to return an invalid object to an object pool");
				return;
			}
			if (!m_poolDictionary.ContainsKey(a_poolable.PoolId))
			{
				Destroy(a_poolable.gameObject);
				return;
			}

			a_poolable.gameObject.SetActive(false);

			var pool = m_poolDictionary[a_poolable.PoolId];

			pool.Enqueue(a_poolable);
		}

		public void ReturnObject(PoolableObject a_poolable, float a_delay, bool a_useScaledTime = true)
		{
			//starting the coroutine on the PoolableObject instead of this component is important
			//so that we can cancel the coroutine if the object is returned to its pool before the delay finishes
			a_poolable.StartCoroutine(ReturnObjectRoutine(a_poolable, a_delay, a_useScaledTime));
		}

		IEnumerator ReturnObjectRoutine(PoolableObject a_object, float a_delay, bool a_useScaledTime)
		{
			if (a_useScaledTime)
			{
				yield return new WaitForSeconds(a_delay);
			}
			else
			{
				yield return new WaitForSecondsRealtime(a_delay);
			}

			ReturnObject(a_object);
		}

		public void DestroyPool(PoolableObject a_poolObject)
		{
			if (!a_poolObject)
			{
				Debug.LogError("Tried to destroy an object pool by passing in an invalid object");
				return;
			}

			int poolId;

			//check if object passed in was a prefab or an instance
			if (a_poolObject.GetInstanceID() > 0)
			{
				poolId = a_poolObject.GetInstanceID();
			}
			else
			{
				poolId = a_poolObject.PoolId;
			}

			if (!m_poolDictionary.ContainsKey(poolId))
			{
				return;
			}
			var pool = m_poolDictionary[poolId];

			while (pool.Count > 0)
			{
				Destroy(pool.Dequeue().gameObject);
			}
			m_poolDictionary.Remove(poolId);
		}

		public void DestroyAllPools()
		{
			foreach (var poolPair in m_poolDictionary)
			{
				while (poolPair.Value.Count > 0)
				{
					Destroy(poolPair.Value.Dequeue().gameObject);
				}
				poolPair.Value.Clear(); //probably not needed but just to be safe
			}

			m_poolDictionary.Clear();

			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
