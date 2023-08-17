using Services.StorageService;
using System.Collections.Generic;

namespace Services.Economic
{
    public class FigureRepository : IFigureService
    {
        public event IFigureService.NewFigureSelected OnNewFigureSelected;
        public Figure selectedFigure
        {
            get => _selectedFigure;
            private set
            {
                selectedFigure = value;
                OnNewFigureSelected?.Invoke(value);
            }
        }
        private Figure _selectedFigure;

        public IReadOnlyDictionary<Figure, ItemStatus> figures => _seller.allItems;

        private const string _saveKey = "figureRepository";
        private Seller<Figure> _seller;

        public FigureRepository(FigureDatabase database, IStoregeService storegeService, IBankService bank)
        {
            _seller = new Seller<Figure>(database.figures, storegeService, bank, _saveKey);
            _seller.OnNewItemSelected += SelectNewFigure;
        }
        public void Initialize()
        {
            _selectedFigure = _seller.selectedItem;
        }

        public bool OpenFigure(Figure figure)
        {
            return _seller.OpenItem(figure);
        }

        public bool SelectFigure(Figure figure)
        {
            return _seller.SelectItem(figure);
        }

        public void Shutdown()
        {

        }

        private void SelectNewFigure(Figure figure)
        {
            selectedFigure = figure;
        }
    }
}
