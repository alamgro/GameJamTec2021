using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference : MonoBehaviour
{
	/* La funcion nos manda a un hiper vinculo a web,  para darnos a conocer en dieferentes medio
	  * Alexander Iniguez
	  * 
	 */
	public void Link(string links)
	{
		Application.OpenURL(links); //te manda al url indicado

	}
}
