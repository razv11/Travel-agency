using System;

namespace networking.dto
{
    [Serializable]
    public class FilterDTO
    {
        private string _landmark;
        private int _startHour;
        private int _endHour;

        public FilterDTO(string landmark, int startHour, int endHour)
        {
            _landmark = landmark;
            _startHour = startHour;
            _endHour = endHour;
        }

        public virtual string Landmark
        {
            get
            {
                return _landmark;
            }
        }

        public virtual int StratHour
        {
            get
            {
                return _startHour;
            }
        }

        public virtual int EndHour
        {
            get
            {
                return _endHour;
            }
        }
    }
}