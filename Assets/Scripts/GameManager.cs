using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // has the user pressed start?
    bool m_hasLevelStarted = false;
    public bool HasLevelStarted { get { return m_hasLevelStarted; } set { m_hasLevelStarted = value; } }

    // have we begun gamePlay?
    bool m_isGamePlaying = false;
    public bool IsGamePlaying { get { return m_isGamePlaying; } set { m_isGamePlaying = value; } }

    // have we met the game over condition?
    bool m_isGameOver = false;
    public bool IsGameOver { get { return m_isGameOver; } set { m_isGameOver = value; } }
    public bool isWinner;

    // have the end level graphics finished playing?
    bool m_hasLevelFinished = false;
    public bool HasLevelFinished { get { return m_hasLevelFinished; } set { m_hasLevelFinished = value; } }

    // delay in between game stages
    public float delay = 1f;

    // events invoked for StartLevel/PlayLevel/EndLevel coroutines
    public UnityEvent setupEvent;
    public UnityEvent startLevelEvent;
    public UnityEvent playLevelEvent;
    public UnityEvent endLevelEvent;
    public UnityEvent loseLevelEvent;


    void Start()
    {
            StartCoroutine("RunGameLoop");
    }

    // run the main game loop, separated into different stages/coroutines
    IEnumerator RunGameLoop()
    {
        yield return StartCoroutine("StartLevelRoutine");
        yield return StartCoroutine("PlayLevelRoutine");
        yield return StartCoroutine("EndLevelRoutine");
    }

    // the initial stage after the level is loaded
    IEnumerator StartLevelRoutine()
    {
        Debug.Log("SETUP LEVEL");
        if (setupEvent != null)
        {
            setupEvent.Invoke();
        }

        Debug.Log("START LEVEL");

        while (!m_hasLevelStarted)
        {
            //show start screen
            // user presses button to start
            // HasLevelStarted = true
            yield return null;
        }

        // trigger events when we press the StartButton
        if (startLevelEvent != null)
        {
            startLevelEvent.Invoke();
        }
    }

    // gameplay stage
    IEnumerator PlayLevelRoutine()
    {
        Debug.Log("PLAY LEVEL");
        m_isGamePlaying = true;
        yield return new WaitForSeconds(delay);

        // trigger any events as we start playing the level
        if (playLevelEvent != null)
        {
            playLevelEvent.Invoke();
        }

        while (!m_isGameOver)
        {
            // pause one frame
            yield return null;

            // check for level win condition
            m_isGameOver = isWinner;

            // check for the lose condition
        }
        // Debug.Log("WIN! ==========================");
    }

    public void LoseLevel()
    {
        StartCoroutine(LoseLevelRoutine());
    }

    // trigger the "lose" condition
    IEnumerator LoseLevelRoutine()
    {
    	// game is over
        m_isGameOver = true;

        // wait for a short delay then...
        yield return new WaitForSeconds(1.5f);

        // ...invoke loseLoveEvent
        if (loseLevelEvent != null)
        {
            loseLevelEvent.Invoke();
        }

        // pause for two seconds and then restart the level
        yield return new WaitForSeconds(2f);

        Debug.Log("LOSE! =============================");

        RestartLevel();
    }

    // end stage after gameplay is complete
    IEnumerator EndLevelRoutine()
    {
        Debug.Log("END LEVEL");

        // run events when we end the level
        if (endLevelEvent != null)
        {
            endLevelEvent.Invoke();
        }

        // show end screen
        while (!m_hasLevelFinished)
        {
            // user presses button to continue

            // HasLevelFinished = true
            yield return null;
        }

        // reload the current scene
        RestartLevel();
    }

    // restart the current level
    void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // attach to StartButton, triggers PlayLevelRoutine
    public void PlayLevel()
    {
        m_hasLevelStarted = true;
    }
}
