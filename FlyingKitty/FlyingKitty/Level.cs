﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingKitty
{
    internal class Level
    {
        private string _hashMap;
        public double GameSpeed { get; set; }
        public int WidthTubes {get; set;}
        public int HeightTubes {get; set;}
        public int DistanceBetweenObjects {get; set;}
        public int HeightWindows {get; set;}
        public int DistanceBetweenWindows {get; set;}
        public double MassPlayer { get; set;}
        public int PushTimePlayer { get; set;}
        public int WidthPlayer { get; set;}
        public int HeigthPlayer { get; set;}
        public Level(string hashMap)
        {
            _hashMap = hashMap;
            GameSpeed = 300 / Game.TICKRATE;
            WidthTubes = 80;
            HeightTubes = 700;
            DistanceBetweenObjects = 10;
            HeightWindows = 200;
            DistanceBetweenWindows = 50;
            MassPlayer = 70;
            PushTimePlayer = 200;
            WidthPlayer = 50;
            HeigthPlayer = 105;
        }
    }
}
