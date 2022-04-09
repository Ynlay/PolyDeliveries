using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStatsController : MonoBehaviour
{
    public Slider healthBar;
    public Slider heatBar;
    public Slider ratingBar;
    public Image foodImage;
    public TextMeshProUGUI address;

    // IMAGE
    public void ChangeSprite(Sprite _sprite) {
        foodImage.sprite = _sprite;
    }

    // HEALTH
    public float GetHealth() {
        return healthBar.value;
    }

    public void SetHealth(float _health) {
        healthBar.value = _health;
    }

    public void SetMaxHealth(float _max) {
        healthBar.maxValue = _max;
    }

    // RATING
    public float GetRating() {
        return ratingBar.value;
    }

    public void SetRating(float _rating) {
        ratingBar.value = _rating;
    }

    public void SetMaxRating(float _max) {
        ratingBar.maxValue = _max;
    }

    // HEAT
    public float GetHeat() {
        return heatBar.value;
    }

    public void SetHeat(float _heat) {
        heatBar.value = _heat;
    }

    public void SetMaxHeat(float _max) {
        heatBar.maxValue = _max;
    }

    // NAME
    public string GetAddress() {
        return address.text;
    }

    public void SetAddress(string _address) {
        address.text = _address;
    }
}
