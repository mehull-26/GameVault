using System.Collections.Generic;
using UnityEngine;

//This script is attached to player in Scene1
public class tryScript1 : MonoBehaviour
{
    void Start()
    {
        //Two types of saving systems are available: RegSave and LocalSave
        //RegSave is used to save data for immediate use

        // Using regSave is relatively simpler
        // Just save the data using GameVault.factory.{typeofSaveSystem}.Save(key, value)
        // RegSave supports int, float and string types only

        // Saving using RegSaveSystem
        GameVault.factory.RegSaveSystem.Save("playerName", "John Boe");

        // Loading using RegSaveSystem
        string playerName = GameVault.factory.RegSaveSystem.Load<string>("playerName");

    }

    // Update is called once per frame
    void Update()
    {
        // No need to attach the GameVault script in multiple scenes,
        // just add once and the factory object will be throughout the lifetime
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Scene change!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene2");
        }
    }
}
