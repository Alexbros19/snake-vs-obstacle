using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryButton : MonoBehaviour {
	public Sprite[] buttonsSprites = new Sprite[19];
	public Sprite[] snakeSkins = new Sprite[18];
	public int NumberButton = 1; // число по замовчуванню на кнопці
	private int countButton = 18; // кількість кнопок
	private string keyNumberButton = "NumberButton";

	void Start(){
		//PlayerPrefs.DeleteAll ();
		int valueButton = 0;

		for(int i = 1; i <= countButton; i++){	
			if(PlayerPrefs.HasKey(keyNumberButton + i.ToString())) //	возвращает true, если ключ существует в хранилище	
			{
				valueButton = PlayerPrefs.GetInt(keyNumberButton + i.ToString()); // зчитуємо збереженне значення для кожної і-тої кнопки
				SetSpriteImage(i,valueButton); // встановлюємо для кожної кнопки її збережене значення
			}
			else
			{
				valueButton = i;               // якщо значення не збережене, то для третьої кнопки (наприклад) тре встановити значення по замовчуванню 3	
				SetSpriteImage(i,valueButton); // встановлюємо для кожної кнопки її збережене значення
			}
		}
	}

	void SetSpriteImage(int numberButton, int valueButton) // numberButton - номер кнопки 1,2,3... valueButton - значення на кнопці, яке тре встановити
	{
		Image buttonImage;
		buttonImage = GameObject.FindGameObjectWithTag("InventoryButton" + numberButton.ToString()).GetComponent<Image>();
		if(valueButton == 0)
		{
			buttonImage.sprite = snakeSkins [numberButton-1];
		}
		else
		{
			buttonImage.sprite = buttonsSprites [valueButton];
		}		
	}


	public void OnInventoryButtonClick(){
		// NumberButton - це номер кнопки на яку клікнули, тобто перша, друга, третя... задаєм з юніті
		int valueButton = 0;
		if (PlayerPrefs.GetInt ("gamescounter", ClearBackgroundImage.gamesCounter) > 0) {       // якась твоя перевірка
			if (PlayerPrefs.HasKey (keyNumberButton + NumberButton.ToString ())) {                //	возвращает true, если ключ существует в хранилище	
				valueButton = PlayerPrefs.GetInt (keyNumberButton + NumberButton.ToString ()); // зчитуємо збереженне значення для NumberButton кнопки
			} else {
				valueButton = NumberButton; 
			}
			valueButton--;
			if (valueButton < 0) {
				valueButton = 0;
				SceneManager.LoadScene ("Menu");
				PlayerPrefs.SetInt ("PressedButtonNumber", NumberButton);
				PlayerPrefs.Save ();
			} else {
				ClearBackgroundImage.gamesCounter--;
				if (ClearBackgroundImage.gamesCounter < 0)
					ClearBackgroundImage.gamesCounter = 0;
		
				PlayerPrefs.SetInt ("gamescounter", ClearBackgroundImage.gamesCounter);
				PlayerPrefs.Save ();
			}
			// зберігаєм нове значення для цієї кнопки NumberButton
			PlayerPrefs.SetInt (keyNumberButton + NumberButton.ToString (), valueButton);
			PlayerPrefs.Save ();
			//---
			SetSpriteImage (NumberButton, valueButton);
		} 
		else 
		{
			if (PlayerPrefs.HasKey (keyNumberButton + NumberButton.ToString ())) {                //	возвращает true, если ключ существует в хранилище	
				valueButton = PlayerPrefs.GetInt (keyNumberButton + NumberButton.ToString ()); // зчитуємо збереженне значення для NumberButton кнопки
			} else {
				valueButton = NumberButton; 
			}

			if (valueButton == 0) {
				SceneManager.LoadScene ("Menu");
				PlayerPrefs.SetInt ("PressedButtonNumber", NumberButton);
				PlayerPrefs.Save ();
			}
		}
	}
}