using ViewElements.Button;

namespace ViewElements
{
    public interface ITongue
    {
        public delegate void Click(TongueButton tongue);
        public event Click OnClick;
        public bool isAcktive { get; }
        public void SwitchOn();
        public void SwitchOff();
    }
}

