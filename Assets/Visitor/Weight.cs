using System;
using UnityEngine;

namespace Assets.Visitor
{
    public class Weight
    {
        private readonly int _maxWeight = 100;
        private readonly EnemyVisitor _enemyVisitor = new();
        private int Value => _enemyVisitor.Weight;

        public event Action WeightReached;
        
        public void OnEnemySpawned(Enemy enemy)
        {
            _enemyVisitor.Visit(enemy);
            
            if (Value >= _maxWeight)
                WeightReached?.Invoke();
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Weight { get; private set; }

            public void Visit(Elf elf) => Weight += 10;

            public void Visit(Human human) => Weight += 5;

            public void Visit(Ork ork) => Weight += 20;

            public void Visit(Robot robot) => Weight += 15;

            public void Visit(Enemy enemy) => Visit((dynamic) enemy);
        }
    }
}