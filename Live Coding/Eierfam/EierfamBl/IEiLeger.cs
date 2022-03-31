﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EierfamBl
{
    public interface IEiLeger
    {
        ObservableCollection<Ei> Eier { get; set; }
        double Gewicht { get; set; }

        void EiLegen();
    }
}