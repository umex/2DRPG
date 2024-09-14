using UnityEngine;

public class PlayerManager: MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        // we are checkinf if we used the same instance of a player somewhere else by a mistake 
        // so if we did we will destroy it
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
}