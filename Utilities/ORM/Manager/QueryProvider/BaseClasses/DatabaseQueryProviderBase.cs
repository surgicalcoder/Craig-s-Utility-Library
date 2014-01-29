﻿/*
Copyright (c) 2014 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Utilities.DataTypes;
using Utilities.DataTypes.Patterns.BaseClasses;
using Utilities.ORM.Manager.QueryProvider.Default;
using Utilities.ORM.Manager.QueryProvider.Interfaces;
using Utilities.ORM.Manager.Schema.Interfaces;

#endregion Usings

namespace Utilities.ORM.Manager.QueryProvider.BaseClasses
{
    /// <summary>
    /// Database query provider base class
    /// </summary>
    public abstract class DatabaseQueryProviderBase : Utilities.ORM.Manager.QueryProvider.Interfaces.IQueryProvider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected DatabaseQueryProviderBase()
            : base()
        {
        }

        /// <summary>
        /// Provider name
        /// </summary>
        public abstract string ProviderName { get; }

        /// <summary>
        /// Parameter prefix
        /// </summary>
        protected abstract string ParameterPrefix { get; }

        /// <summary>
        /// Returns a batch object
        /// </summary>
        /// <param name="ConnectionString">Connection string</param>
        /// <returns>Batch object</returns>
        public IBatch Batch(string ConnectionString)
        {
            return new DatabaseBatch(ConnectionString, ParameterPrefix, ProviderName);
        }

        /// <summary>
        /// Creates a generator class for the appropriate provider
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>A generator class</returns>
        public abstract IGenerator<T> Generate<T>(string ConnectionString)
            where T : class;
    }
}