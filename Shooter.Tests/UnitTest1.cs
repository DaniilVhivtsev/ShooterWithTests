using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shooter;
using Shooter.Model;
using Shooter.Entites;
using System.Drawing;
using Shooter.Controllers;

namespace Shooter.Tests
{
    public class Tests
    {
        private Entity hero = new Entity(0, 0, 0, 0, 0, 0, null);
        private Enemy enemy;

        [Test]
        public void HeroIsDeath()
        {
            Entity.Health -= 101;
            var heroIsDeath = Entity.Death;
            Assert.AreEqual(true, heroIsDeath);
        }

        [Test]
        public void enemyIsDeath()
        {
            enemy = new Enemy(100);
            enemy.Health -= 120;
            Assert.AreEqual(true, enemy.Death);
        }

        [Test]
        public void BulletHitsHero()
        {
            var endPointX = 100;
            var endPointY = 100;

            var bullet = new Phisics_Of_Shoot(new Point(0, 0), new Point(endPointX, endPointY));
            for (int i = 0; i < 10; i++)
                bullet.MakeShootEnemy();
            Assert.AreEqual(endPointX + 5, bullet.Position.X);
            Assert.AreEqual(endPointY + 10, bullet.Position.Y);
        }

        [Test]
        public void HeroHealthDecreasse()
        {
            Entity.Health = 100;
            var bullet = new Phisics_Of_Shoot(new Point(100, 100), new Point(Entity.PosX, Entity.PosY));
            for (int i = 0; i < 10; i++)
                bullet.MakeShootEnemy();
            Assert.AreEqual(true, Entity.Health < 100 && Entity.Health >= 50);
        }
    }
}