//Efficiente ma utilizzabile solo in caso specifico
{
    foreach (Transform child in parent.GetComponentsInChildren<Transform>())
    {
		if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
	}
}

//Metodo Ricorsivo funzionante per ricerca di singolo figlio
//Non molto efficiente, ma molto funzionale ed utilizzabile
private GameObject RecursiveFindChild(Transform parent, string childName)
{
	foreach (Transform child in parent)
	{
		if (child.name == childName)
		{
			return child.gameObject;
		}
		else
		{
			GameObject found = RecursiveFindChild(child, childName);
			if (found != null)
			{
				return found;
			}
		}
	}
	return null;
}

//Metodo ricorsivo efficiente per ricerca singolo figlio
//Più efficiente del precedente, molto funzionale ed utilizzabile
public static Transform FindChild(Transform trans, string goName)
{
	Transform child = trans.Find(goName);
	if (child != null)
		return child;

	Transform go = null;
	for (int i = 0; i < trans.childCount; i++)
	{
		child = trans.GetChild(i);
		go = FindChild(child, goName);
		if (go != null)
			return go;
	}
	return null;
}

//Funzionante, qual è migliore tra questo metodo e il precedente?
private void RecursiveFindChild(Transform parent)
{
	foreach (Transform child in parent)
	{
		if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
		else if (child.name == "nome")
		{
			//Do something
		}
		RecursiveFindChild(child);
	}
}
	