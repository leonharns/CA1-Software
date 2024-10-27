using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
    public class NewTestScript
    {
        private GameObject enemy;
        private GameObject player;
        //private EnemyAI enemyAI;

        //[SetUp]
        //public void Setup()
        //{
        //    enemy = new GameObject();
        //    player = new GameObject();

        //    enemyAI = enemy.AddComponent<EnemyAI>();
        //    enemyAI.player = player.transform;
        //    enemyAI.fieldOfViewAngle = 90f;
        //    enemyAI.detectionRange = 10f;
        //}

        //[Test]
        //public void PlayerInFieldOfView()
        //{
        //    // Position the player within the field of view and detection range
        //    player.transform.position = enemy.transform.position + enemy.transform.forward * 5;

        //    // Check if CanSeePlayer() detects the player
        //    Assert.IsTrue(enemyAI.CanSeePlayer(), "Enemy should detect the player within field of view.");
        //}

        //[Test]
        //public void PlayerOutOfFieldOfView()
        //{
        //    // Position the player outside the field of view
        //    player.transform.position = enemy.transform.position + enemy.transform.right * 5;

        //    // Check if CanSeePlayer() fails to detect the player
        //    Assert.IsFalse(enemyAI.CanSeePlayer(), "Enemy should not detect the player outside field of view.");
        //}

        //[Test]
        //public void PlayerOutOfDetectionRange()
        //{
        //    // Position the player outside the detection range
        //    player.transform.position = enemy.transform.position + enemy.transform.forward * 15;

        //    // Check if CanSeePlayer() fails to detect the player due to distance
        //    Assert.IsFalse(enemyAI.CanSeePlayer(), "Enemy should not detect the player outside detection range.");
        //}
    }

