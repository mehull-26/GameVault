using UnityEngine;

public class GameVault : MonoBehaviour
{
    public static GameVault factory { get; private set; }

    public GameVaultSettings Settings;
    public RegistrySave RegSaveSystem;
    public LocalSave LocalSaveSystem;

    void Awake()
    {
        if (factory != null && factory != this)
        {
            Debug.Log("Singleton exists! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        factory = this;
        Settings= new GameVaultSettings();
        LocalSaveSystem = new LocalSave();
        RegSaveSystem = new RegistrySave();

        DontDestroyOnLoad(gameObject);

    }
}
