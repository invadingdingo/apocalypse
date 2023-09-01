using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // Check for the "Esc" key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the game
            Application.Quit();
        }

        // Check for the "R" key press
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the current scene
            ResetScene();
        }
    }

    // Function to reset the current scene
    void ResetScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene to reset it
        SceneManager.LoadScene(currentSceneIndex);
    }
}