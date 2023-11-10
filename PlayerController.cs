/*Property of Sadie Sundt, Bournemouth University. 2020. Programming for Interaction. PlayerController.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public Rigidbody rb;
	public static int coinsCollected = 0;
	public Text scoreText;
	public float timeStart = 30.0f;
	public Text timerText;
	public float addTime = 5.0f;
	public Text finalScore;
	public AudioClip coingain;
	public AudioSource audio;

	/*This starts the processes needed for every level, including gaining the coins and deleting them if it is level 1. 
	The game over text is also set here by gaining the text from the other levels.
	 */
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		if(sceneName == "Level1")
        {
			PlayerPrefs.DeleteAll();
			coinsCollected = 0;
        }

		if(sceneName == "GameOver")
        {
			SetFinalScoreText();
        }

		SetScoreText();

		coinsCollected = PlayerPrefs.GetInt("Coins Collected", coinsCollected);

	}
	
	/* This update function controls the player movements as well as updates the timer continuously throughout the game. 
	   The function also allows for the timer to move to the game over scene if the time hits 0.
	 */
	void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed * Time.deltaTime);

		timeStart -= Time.deltaTime;
		timerText.text = "" + timeStart;

		if (timeStart < 0)
        {
			SceneManager.LoadScene("GameOver");
        }
	}
	/*This on trigger function sets the various options such as when the player hits the pickup, it'll add to the score and play the sound.
	  The timer tag allows the player to recognise when the cylinder has been hit and the timer will add time.
	  The portal tag allows the next scene to start with the right amount of coins.
	 */
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") 
		{
			SetScoreText();
			other.gameObject.SetActive (false);
			audio.PlayOneShot(coingain);
		} 
		else if (other.gameObject.tag == "Timer") 
		{
			AddTime();
			other.gameObject.SetActive (false);
		} 
		else if (other.gameObject.tag == "Portals")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			coinsCollected = coinsCollected - 1;
		}
	}
	//This sets the Score UI text, and also increments the score when applicapple. This also sets the score so it will be what it should be.
	void SetScoreText()
    {
		scoreText.text = "" + coinsCollected;
		coinsCollected++;
		PlayerPrefs.SetInt("Coins Collected", coinsCollected);
    }
	//This adds time to the UI time text.
	public void AddTime()
    {
		timeStart = timeStart + addTime;
		timerText.text = "" + timeStart;
    }
	//This sets the final score UI text that will show when the game over screen is shown
	public void SetFinalScoreText()
    {
		coinsCollected = coinsCollected - 1;
		finalScore.text = "" + coinsCollected;
	}
}
