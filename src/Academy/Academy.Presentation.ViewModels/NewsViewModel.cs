﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels
{
    public abstract class NewsViewModel : EntityViewModel
    {
        public bool Read
        {
            get;
            set;
        }
    }
}
