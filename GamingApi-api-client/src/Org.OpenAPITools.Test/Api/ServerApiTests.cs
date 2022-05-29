/* 
 * GamingEventApi API
 *
 * GamingEventApi API for the rust server
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: jonas-lt@live.dk
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test
{
    /// <summary>
    ///  Class for testing ServerApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ServerApiTests
    {
        private ServerApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ServerApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ServerApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' ServerApi
            //Assert.IsInstanceOf(typeof(ServerApi), instance);
        }

        
        /// <summary>
        /// Test GetAchievementGroupsOfServer
        /// </summary>
        [Test]
        public void GetAchievementGroupsOfServerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //var response = instance.GetAchievementGroupsOfServer(serverId);
            //Assert.IsInstanceOf(typeof(List<AchievementGroup>), response, "response is List<AchievementGroup>");
        }
        
        /// <summary>
        /// Test GetAchievementsOfServer
        /// </summary>
        [Test]
        public void GetAchievementsOfServerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //var response = instance.GetAchievementsOfServer(serverId);
            //Assert.IsInstanceOf(typeof(List<Achievement>), response, "response is List<Achievement>");
        }
        
        /// <summary>
        /// Test GetCombatKillsOnWipe
        /// </summary>
        [Test]
        public void GetCombatKillsOnWipeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int wipeId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetCombatKillsOnWipe(serverId, wipeId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<CombatKill>), response, "response is List<CombatKill>");
        }
        
        /// <summary>
        /// Test GetHuntForWeaponsForCurrentWipe
        /// </summary>
        [Test]
        public void GetHuntForWeaponsForCurrentWipeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetHuntForWeaponsForCurrentWipe(serverId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<HuntForWeapon>), response, "response is List<HuntForWeapon>");
        }
        
        /// <summary>
        /// Test GetHuntForWeaponsForWipe
        /// </summary>
        [Test]
        public void GetHuntForWeaponsForWipeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int wipeId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetHuntForWeaponsForWipe(serverId, wipeId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<HuntForWeapon>), response, "response is List<HuntForWeapon>");
        }
        
        /// <summary>
        /// Test GetLeaderboards
        /// </summary>
        [Test]
        public void GetLeaderboardsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetLeaderboards(serverId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<LeaderBoardPlayer>), response, "response is List<LeaderBoardPlayer>");
        }
        
        /// <summary>
        /// Test GetLeaderboardsForWipe
        /// </summary>
        [Test]
        public void GetLeaderboardsForWipeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int wipeId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetLeaderboardsForWipe(serverId, wipeId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<LeaderBoardPlayer>), response, "response is List<LeaderBoardPlayer>");
        }
        
        /// <summary>
        /// Test GetServer
        /// </summary>
        [Test]
        public void GetServerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //var response = instance.GetServer(serverId);
            //Assert.IsInstanceOf(typeof(Server), response, "response is Server");
        }
        
        /// <summary>
        /// Test GetServerCombatKills
        /// </summary>
        [Test]
        public void GetServerCombatKillsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetServerCombatKills(serverId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<CombatKill>), response, "response is List<CombatKill>");
        }
        
        /// <summary>
        /// Test GetServerWipes
        /// </summary>
        [Test]
        public void GetServerWipesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //int? offset = null;
            //int? limit = null;
            //var response = instance.GetServerWipes(serverId, offset, limit);
            //Assert.IsInstanceOf(typeof(List<Wipe>), response, "response is List<Wipe>");
        }
        
        /// <summary>
        /// Test GetServers
        /// </summary>
        [Test]
        public void GetServersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetServers();
            //Assert.IsInstanceOf(typeof(List<Server>), response, "response is List<Server>");
        }
        
        /// <summary>
        /// Test GetTitlesFromServer
        /// </summary>
        [Test]
        public void GetTitlesFromServerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int serverId = null;
            //var response = instance.GetTitlesFromServer(serverId);
            //Assert.IsInstanceOf(typeof(List<Title>), response, "response is List<Title>");
        }
        
    }

}
