using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> draggables;

    public void PrintSomething(GameObject thought)
    {
        Debug.Log("Thought: " + thought.name);
    }

    public void ActivateThought(GameObject thought)
    {
        if(thought == draggables[0])
        {
            // Start the Game
            SceneManager.LoadScene(1);
        }
        else if (thought == draggables[1])
        {
            // Show the Credits
        }
        else
        {
            // Quit the Game
            Application.Quit();
        }
    }
}
