﻿using System;
using System.Linq;
using EntityFramework.Caching;
using EntityFramework.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracker.SqlServer.CodeFirst;

namespace Tracker.SqlServer.EF5.NET451.Tests
{
    [TestClass]
    public class CacheDbContext
    {
        [TestMethod]
        public void FromCacheTest()
        {
            var db = new TrackerContext();
            var roles = db.Roles.FromCache();
            roles.Should().NotBeEmpty();

            var roles2 = db.Roles.FromCache();
            roles2.Should().NotBeEmpty();
        }

        [TestMethod]
        public void FromCacheFirstOrDefaultTest()
        {
            var db = new TrackerContext();
            var role = db.Roles.FromCacheFirstOrDefault();
            role.Should().NotBeNull();

            var role2 = db.Roles.FromCacheFirstOrDefault();
            role2.Should().NotBeNull();
        }

        [TestMethod]
        public void TaskFromCacheTest()
        {
            var db = new TrackerContext();

            int myUserId = 0;

            //query result is now cached 300 seconds
            var tasks = db.Tasks
                .Where(t => t.AssignedId == myUserId && t.CompleteDate == null)
                .FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(300)));

            // cache assigned tasks
            var tagTasks = db.Tasks
                .Where(t => t.AssignedId == myUserId && t.CompleteDate == null)
                .FromCache(tags: new[] { "Task", "Assigned-Task-" + myUserId });

            // some update happened, expire task tag
            CacheManager.Current.Expire("Task");


        }

        [TestMethod]
        public void TaskProjectionFromCacheTest()
        {
            var db = new TrackerContext();

            int myUserId = 0;

            //query result is now cached 300 seconds
            var tasks = db.Tasks
                .Select(t => new TaskLookup
                {
                    Id = t.Id,
                    Summary = t.Summary
                })
                .FromCache()
                .ToList();



        }

    }

    public class TaskLookup
    {
        public int Id { get; set; }
        public string Summary { get; set; }

    }
}
