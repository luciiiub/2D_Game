using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScene : MonoBehaviour
{
    public int score = 0;         // Puntaje actual del jugador
    public Text textoPuntuacion;        // Texto UI donde se muestra el puntaje

    private void Start()
    {
        // Asegura que el tiempo del juego este activo (por si estaba pausado antes)
        UnityEngine.Time.timeScale = 1.0f;
    }

    void Update()
    {
        // Actualiza el texto del puntaje en pantalla cada frame
        textoPuntuacion.text = "Score: " + score.ToString();
    }

    // Suma puntos al puntaje actual
    public void AddScore(int i)
    {
        score += i;
    }

    // Resta puntos del puntaje actual
    public void RemoveScore(int i)
    {
        score -= i;
    }

    // Cambia a otra escena por nombre
    public void __GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    // Sale del juego 
    public void __ExitGame()
    {
        Application.Quit();
    }
}
