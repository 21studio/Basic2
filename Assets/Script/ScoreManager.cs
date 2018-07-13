using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreManager : MonoBehaviour {

	//아래 방식과 같다
	//호출 예시
	public static ScoreManager instance { get; private set; }

	//호출 예시
	static ScoreManager _instance = null;
	public static ScoreManager Instance() {
		return _instance;
	}

	bool gamePause = false;

	void Start () {
		if (_instance == null)
			_instance = instance = this;
		else
			Destroy(gameObject);

		LoadBestScore();
	}

	public int bestScore { 
		get; 
		private set; 
	}

	public Text scoreText;
	StringBuilder scroeTextBuilder = new StringBuilder();
	
	private void Update () {
		scroeTextBuilder.Length = 0;
		scroeTextBuilder.AppendFormat("Best Score : {0}\nScore : {1}", bestScore, myScore);
		scoreText.text = scroeTextBuilder.ToString();

		if (Input.GetKeyDown(KeyCode.Escape)) {
			gamePause = !gamePause;

			if (gamePause == true)
				Time.timeScale = 0.0f;
			else
				Time.timeScale = 1.0f;
		}
	}

	int _myScore = 0;
	public int myScore {
		get { 
			return _myScore; 
		}
		set {
			_myScore = value;
			if (_myScore > bestScore) {
				bestScore = _myScore;
				SaveBestScore();
			}
		}
	}

	void SaveBestScore () {
		PlayerPrefs.SetInt("Best Score", bestScore);
	}

	void LoadBestScore () {
		bestScore = PlayerPrefs.GetInt("Best Score", 0);
	}
}
