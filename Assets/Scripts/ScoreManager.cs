using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int[] lives = new int[4]; 
    public TextMeshProUGUI[] lifeTexts; 
    public RaycastManager[] raycastManagers; 

    void Start()
    {
       
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i] = 15;
            UpdateLifeText(i);
        }
    }

    public void DecreaseLife(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < lives.Length)
        {
            lives[playerIndex]--;
            UpdateLifeText(playerIndex);

            
            if (lives[playerIndex] <= 0)
            {
                StopGame(playerIndex);
            }
        }
    }

    private void UpdateLifeText(int playerIndex)
    {
        if (lifeTexts[playerIndex] != null)
        {
            lifeTexts[playerIndex].text = "Vidas: " + lives[playerIndex].ToString();
        }
    }

    private void StopGame(int playerIndex)
    {
        
        Debug.Log("Jugador " + playerIndex + " ha llegado a 0 vidas. El juego se detiene.");
      
        Time.timeScale = 0; 
    }
}
