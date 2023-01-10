using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureRepository : MonoBehaviour
{
    public GameObject[] Figures;
    public int ActiveFigureIndex;
    public bool[] IsFigureOpen;

    public GameObject GetActiveFigure() 
    { 
        return Figures[ActiveFigureIndex];
    }
    public void LoadData(Save.FigureRepositoryData data) 
    { 
        this.ActiveFigureIndex = data.ActiveFigureIndex;
    }
}
