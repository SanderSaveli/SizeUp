using System.Collections.Generic;

namespace Services.Economic
{
    public interface IFigureService : IService
    {
        public delegate void NewFigureSelected(Figure figure);
        public event NewFigureSelected OnNewFigureSelected;
        public Figure selectedFigure { get; }
        public IReadOnlyDictionary<Figure, ItemStatus> figures { get; }

        public bool OpenFigure(Figure figure);
        public bool SelectFigure(Figure figure);
    }
}

