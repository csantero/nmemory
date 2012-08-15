﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMemory.Test.Data;
using NMemory.Exceptions;

namespace NMemory.Test
{
    [TestClass]
    public class ConstraintFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ConstraintException))]
        public void NCharContraintViolation()
        {
            TestDatabase db = new TestDatabase(createNcharContraintForGroup: true);

            db.Groups.Insert(new Group { Name = "Too long name" });
        }

        [TestMethod]
        public void NCharContraintCompletion()
        {
            TestDatabase db = new TestDatabase(createNcharContraintForGroup: true);

            Group group = new Group { Id = 1, Name = "wat" };
            db.Groups.Insert(group);

            Assert.AreEqual("wat ", db.Groups.Single().Name);
        }
    }
}