using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndgameScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void BackToStart(){
    SceneManager.LoadScene("Start Screen");
    }
}
