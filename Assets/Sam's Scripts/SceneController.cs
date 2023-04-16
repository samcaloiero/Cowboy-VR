using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   // public SceneAsset gameScene;

    public void GoToGameScene()
    {
        //loading the play scene
        //this works in editor
        // string path = AssetDatabase.GetAssetPath(gameScene);
        // SceneManager.LoadScene(path);
        SceneManager.LoadScene("OBI SAM 4-16");

    }
}
