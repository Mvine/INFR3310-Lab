using UnityEngine;
using UnityEngine.Events;

	public class PoolableObject : MonoBehaviour
	{
		public UnityAction onReuse;

		float m_lastResetTime;

		public int PoolId { get; set; }

		public float LastResetTime { get => m_lastResetTime; }

		void OnDisable()
		{
			StopAllCoroutines();
		}

		public void OnReuse()
		{
			m_lastResetTime = Time.time;

			onReuse?.Invoke();
		}

		public void ReturnToPool()
		{
			ObjectPool.Instance.ReturnObject(this);
		}

		public void ReturnToPool(float a_delay, bool a_useScaledTime = true)
		{
			ObjectPool.Instance.ReturnObject(this, a_delay, a_useScaledTime);
		}
	}
