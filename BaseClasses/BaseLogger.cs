﻿using MobileDeliveryLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileDeliveryLogger.BaseClasses
{
    public abstract class BaseLogger
    {
        public static string AppName = "DefaultApp";

        public static LogLevel Level;

        public BaseLogger(string appName="") { if (appName != null && appName.Length > 1) AppName = appName; }

    }
}
