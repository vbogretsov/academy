﻿using System;
using System.IO;

namespace Academy.Presentation.Views.Utils
{
    public static class AcademyEnvironment
    {
        public const string UsersFolderName = "Users";

        public static void Initialize()
        {
            if (!Directory.Exists(UsersFolderName))
            {
                Directory.CreateDirectory(UsersFolderName);
            }
        }
    }
}