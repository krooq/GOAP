﻿using System;
using System.Collections.Generic;
using CrashKonijn.Goap.Core.Interfaces;

namespace CrashKonijn.Goap.Configs
{
    [Serializable]
    public class GoalConfig : IGoalConfig
    {
        public GoalConfig()
        {
            
        }
        
        public GoalConfig(Type type)
        {
            this.Name = type.Name;
            this.ClassType = type.AssemblyQualifiedName;
        }

        public string Name { get; set; }
        public string ClassType { get; set; }
        public int BaseCost { get; set; }
        public List<ICondition> Conditions { get; set; } = new();
        
        public static GoalConfig Create<TGoal>()
            where TGoal : IGoal
        {
            return new GoalConfig(typeof(TGoal));
        }
    }
}