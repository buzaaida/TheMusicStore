﻿namespace TheMusicStore
{
    public class Token
    {
        public string TokenString { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}