using UnityEngine;

public abstract class Singleton<TBehaviour> : MonoBehaviour
    where TBehaviour : MonoBehaviour
{
    static TBehaviour s_instance;

    public static TBehaviour Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<TBehaviour>();

                if (s_instance == null)
                {
                    GameObject instanceObject =
                        new GameObject($"{nameof(TBehaviour)} Singleton", typeof(TBehaviour));

                    //DontDestroyOnLoad(instanceObject);
                }
            }

            return s_instance;
        }
    }

    protected virtual void Awake()
    {
        if (s_instance != null && FindObjectsOfType<TBehaviour>().Length > 1)
        {
            Debug.LogError($"There should only be one instance of \"{nameof(TBehaviour)}\"!", this);
            Debug.Break();
            Destroy(this);
        }
        else
        {
            s_instance = this as TBehaviour;
        }
    }

    protected virtual void OnDestroy()
    {
        if (s_instance == this)
        {
            s_instance = null;
        }
    }

}


public class singleton
{
    singleton instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            //Destroy(this.instance);
        }
        else
        {
            instance = this;
        }
    }
}