using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneGA : MonoBehaviour
{
    public string SceneToGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneToGo);
        }
    
    }
}
