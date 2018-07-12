using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public Text hpText;
	public Slider hpSlider;

	public GameObject gameOverText;
	//public bool isDead = false;
	public bool isDead {
		get {
			return healthPoint <= 0;
		}
	}

	public FireBall fireBall;
	public CameraControl cameraControl;

	CameraShake cameraShake;	

	int _healthPoint = 5;
	public int healthPoint {
		get {
			return _healthPoint;
		}
		set {			
			_healthPoint = value;

			gameOverText.SetActive(isDead);

			fireBall.enabled =!isDead;
			cameraControl.enabled =!isDead;

			/* 
			if (_healthPoint <= 0) {
				gameOverText.SetActive(true);
			}
			else {
				gameOverText.SetActive(false);
			} */
			
			// UI 갱신도 같이하자. 실수를 줄이기 위해
			hpText.text = "HP : " + healthPoint;

			float from = hpSlider.value;
			float to = (float)healthPoint / maxHealthPoint;

			var tweener = LeanTween.value (from, to, 0.3f);
			tweener.setEase(LeanTweenType.easeOutCirc);
			tweener.setOnUpdate(UpdateSlide);

			//hpSlider.value = (float)healthPoint / maxHealthPoint;
		}
	}

	void UpdateSlide(float x) {
		hpSlider.value = x;
	}
	
	public int maxHealthPoint = 5;

	void Start () {
		healthPoint = maxHealthPoint;
		cameraShake = GetComponentInChildren<CameraShake>();
	}
	public void DamageByEnemy() {
		if (isDead)
			return;

		--healthPoint;
		
		cameraShake.PlayCameraShake();
		//healthPoint -= 1;
		//healthPoint = healthPoint - 1;
	}
} 
