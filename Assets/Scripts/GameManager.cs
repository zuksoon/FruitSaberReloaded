using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour {
    [Header("Gameplay")] public bool godMode;

    public GameObject healthBar;

    public float healthFactor;
    [Range(0, 1)] public float hpDrainPerSecond;
    [Range(0, 1)] public float hpDrainPerMiss;
    [Range(0, 1)] public float hpDrainPerScore;

    [Header("UI elements")] public TextMeshPro scoreText;
    public TextMeshPro missText;
    public TextMeshPro comboText;

    [Header("Difficulty")] public GameObject fruitSpawner;
    public float timeToSpeedUp;
    public float speedUp;
    public float startSpeed;
    public float maxSpeed;

    [Header("UI animations")] public Animator scoreTracker;

    public Animator missTracker;
    public Animator comboTracker;

    private int missedFruits;
    private int points;
    private int combo;
    private float healthBarMaxWidth;
    private float health;
    private float speedUpTime;

    private void Start() {
        missedFruits = 0;
        healthBarMaxWidth = healthBar.transform.localScale.x;
        health = 100;
        speedUpTime = 0.0f;
        fruitSpawner.GetComponent<FruitSpawner>().SetTimer(startSpeed);
        fruitSpawner.GetComponent<FruitSpawner>().SetMaxSpeed(maxSpeed);
    }

    private void Update() {
        UpdateHealthBar(HealChangeAction.REDUCE, hpDrainPerSecond * 100 / healthFactor * Time.deltaTime);

        speedUpTime += Time.deltaTime;

        if (speedUpTime >= timeToSpeedUp) {
            speedUpTime = speedUpTime - timeToSpeedUp;
            fruitSpawner.GetComponent<FruitSpawner>().ReduceTimer(speedUp);
        }

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver() {
        if (!godMode) {
            _RestartLevel();
        }
    }

    public void GameOverWithDelay(float delay) {
        if (!godMode) {
            Invoke(nameof(_RestartLevel), delay);
        }
    }

    public void AddMiss() {
        combo = 0;
        missedFruits++;
        // missText.SetText(missedFruits.ToString());
        comboText.SetText($"x{combo}");
        UpdateHealthBar(HealChangeAction.REDUCE, hpDrainPerMiss * 100 / healthFactor);
        // missTracker.Play("MissTrackerPop", 0, 0);
        if (health <= 0) {
            GameOver();
        }
    }

    public void AddPoint() {
        combo++;
        points += combo;
        comboText.SetText($"x{combo}");
        scoreText.SetText(points.ToString());
        UpdateHealthBar(HealChangeAction.GAIN, hpDrainPerScore * 100 / healthFactor);
        // scoreTracker.Play("ScoreTrackerPop", 0, 0);
        // comboTracker.Play("ComboTrackerPop", 0, 0);
    }

    private void UpdateHealthBar(HealChangeAction option, float value) {
        switch (option) {
            case HealChangeAction.REDUCE: {
                health -= value;
                break;
            }
        
            case HealChangeAction.GAIN: {
                health += value;
                break;
            }
        }
        
        if (health > 100) {
            health = 100;
        } else if (health < 0) {
            health = 0;
        }
        
        Vector3 healthBarLocalScale = healthBar.transform.localScale;
        healthBar.transform.localScale = new Vector3(healthBarMaxWidth * health / 100, healthBarLocalScale.y, healthBarLocalScale.y);
    }

    private void _RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

enum HealChangeAction {
    REDUCE,
    GAIN
}