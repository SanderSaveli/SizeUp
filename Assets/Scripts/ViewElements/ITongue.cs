namespace ViewElements
{
    public interface ITongue
    {
        public delegate void Click(ITongue tongue);
        public event Click OnClick;
        public void SwitchOn();
        public void SwitchOff();
    }
}

