using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerScenes : MonoBehaviour
{
	/*Cambia de escena con el string
	 * Alexander Iñiguez
	 * Abril 17, 2021
	 */
      //[SerializeField]
       //public string nameScene;

      public void ChangeScene(string _nameScene)
      {
			SceneManager.LoadScene(_nameScene);
      }

	

}
