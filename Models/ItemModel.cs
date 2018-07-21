using GalaSoft.MvvmLight;

namespace Lesson7.Models
{
    public class ItemModel : ViewModelBase
    {
        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int _Id = 0;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                if (_Id == value)
                {
                    return;
                }

                _Id = value;
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region Qty

        /// <summary>
        /// The <see cref="Qty" /> property's name.
        /// </summary>
        public const string QtyPropertyName = "Qty";

        private int _Qty = 0;

        /// <summary>
        /// Sets and gets the Qty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Qty
        {
            get
            {
                return _Qty;
            }

            set
            {
                if (_Qty == value)
                {
                    return;
                }

                _Qty = value;
                RaisePropertyChanged(QtyPropertyName);
            }
        }

        #endregion

        #region Rate

        /// <summary>
        /// The <see cref="Rate" /> property's name.
        /// </summary>
        public const string RatePropertyName = "Rate";

        private double _Rate = 0.0;

        /// <summary>
        /// Sets and gets the Rate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Rate
        {
            get
            {
                return _Rate;
            }

            set
            {
                if (_Rate == value)
                {
                    return;
                }

                _Rate = value;
                RaisePropertyChanged(RatePropertyName);
            }
        }

        #endregion

        #region Tax

        /// <summary>
        /// The <see cref="Tax" /> property's name.
        /// </summary>
        public const string TaxPropertyName = "Tax";

        private double _Tax = 0.0;

        /// <summary>
        /// Sets and gets the Tax property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Tax
        {
            get
            {
                return _Tax;
            }

            set
            {
                if (_Tax == value)
                {
                    return;
                }

                _Tax = value;
                RaisePropertyChanged(TaxPropertyName);
            }
        }

        #endregion

        #region GST

        /// <summary>
        /// The <see cref="GST" /> property's name.
        /// </summary>
        public const string GSTPropertyName = "GST";

        private double _GST = 0.0;

        /// <summary>
        /// Sets and gets the GST property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double GST
        {
            get
            {
                return _GST;
            }

            set
            {
                if (_GST == value)
                {
                    return;
                }

                _GST = value;
                RaisePropertyChanged(GSTPropertyName);
            }
        }

        #endregion

        #region Amt

        /// <summary>
        /// The <see cref="Amt" /> property's name.
        /// </summary>
        public const string AmtPropertyName = "Amt";

        private double _Amt = 0.0;

        /// <summary>
        /// Sets and gets the Amt property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Amt
        {
            get
            {
                return _Amt;
            }

            set
            {
                if (_Amt == value)
                {
                    return;
                }

                _Amt = value;
                RaisePropertyChanged(AmtPropertyName);
            }
        }

        #endregion

        #region Name

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        public const string NamePropertyName = "Name";

        private string _name = string.Empty;

        /// <summary>
        /// Sets and gets the Name property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        #endregion

    }
}
