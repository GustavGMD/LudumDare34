using UnityEngine;
using System.Collections;

public class GlobalVars {
	private static GlobalVars instance;

	private GlobalVars() {}

	public int levelAtual;

	public int countPerfeito;

	public int countBom;

	public int countErros;

	public int comboMax;

	public int rank;

	//Colocar a planta tbm

	public int plantSelected;

	public static GlobalVars Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new GlobalVars();
			}
			return instance;
		}
	}

}
